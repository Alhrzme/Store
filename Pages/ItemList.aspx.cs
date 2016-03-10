using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Store.Models;
using System.Web.Routing;

namespace Store.Pages
{
    public partial class ItemList : System.Web.UI.Page
    {
        IEnumerable<Item> _items = ItemsDB.GetItemsFromDB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(User.IsInRole("Admins") || User.IsInRole("Employees")))
            {
                admin.Visible = false;
            }
            
        }

        protected int[] pageSizes = { 8, 12, 16 };

        protected int CurrentPageSize
        {
            get
            {
                int pageSize;
                string reqValue = (string)RouteData.Values["pageSize"] ??
                    Request.QueryString["pageSize"];
                return reqValue != null && int.TryParse(reqValue, out pageSize) ? pageSize : 12;
            }
        }

        protected int CurrentPage
        {
            get
            {
                int page = GetPageFromRequest();
                return page > MaxPage ? MaxPage : page;
            }
        }

        protected int MaxPage
        {
            get
            {
                int prodCount = FilterItems().Count();
                return (int)Math.Ceiling((decimal)prodCount / CurrentPageSize);
            }
        }

        private string CurrentCategory
        {
            get
            {
                return (string)RouteData.Values["category"] ??
                Request["category"];
            }
        }

        private int? CurrentMinPrice
        {
            get
            {
                int minPrice;
                string reqValue = (string)RouteData.Values["minPrice"] ??
                    Request.QueryString["minPrice"];
                return reqValue != null && int.TryParse(reqValue, out minPrice) ? minPrice : (int?)null;

            }
        }

        private int? CurrentMaxPrice
        {
            get
            {
                int maxPrice;
                string reqValue = (string)RouteData.Values["maxPrice"] ??
                    Request.QueryString["maxPrice"];
                return reqValue != null && int.TryParse(reqValue, out maxPrice) ? maxPrice : (int?)null;
            }
        }

        private string CurrentSortingType
        {
            get
            {
                return (string)RouteData.Values["sorting"] ??
                 Request.QueryString["sorting"];
            }
        }

        private int GetPageFromRequest()
        {
            int page;
            string reqValue = (string)RouteData.Values["page"] ??
                Request.QueryString["page"];
            return reqValue != null && int.TryParse(reqValue, out page) ? page : 1;
        }

        protected string GetImageLink(int id)
        {
            string path = RouteTable.Routes.GetVirtualPath(null, "RouteDataHandler",
                new RouteValueDictionary()
                {
                    {
                        "id", id
                    }
                }
                ).VirtualPath;
            return string.Format("<img src='{0}' alt=\"Image\" />",path);
        }

        public string GetPageSizeLink(int pageSize)
        {
            string path = RouteTable.Routes.GetVirtualPath(null, null,
                new RouteValueDictionary()
                {
                    {
                        "category", CurrentCategory
                    },
                    {
                        "page", 1
                    },
                    {
                        "sorting", CurrentSortingType
                    },
                    {
                        "minPrice", CurrentMinPrice
                    },
                    {
                        "maxPrice", CurrentMaxPrice
                    },
                    {
                        "pageSize", pageSize
                    }
                }
                ).VirtualPath;
            return path;
        }

        public string GetSortingLink(string attribute)
        {
            string path = RouteTable.Routes.GetVirtualPath(null, null,
                new RouteValueDictionary()
                {
                    {
                        "category", CurrentCategory
                    },
                    {
                        "page", 1
                    },
                    {
                        "sorting", attribute
                    },
                    {
                        "minPrice", CurrentMinPrice
                    },
                    {
                        "maxPrice", CurrentMaxPrice
                    },
                    {
                        "pageSize", CurrentPageSize
                    }
                }
                ).VirtualPath;
            return path;
        }

        public string GetItemPageLink(int id)
        {
            return RouteTable.Routes.GetVirtualPath(null, "item",
                new RouteValueDictionary()
                {
                    {
                        "id", id
                    }
                }).VirtualPath;
        }

        public IEnumerable<Item> GetItems()
        {
            return FilterItems()
                .Skip((CurrentPage - 1) * CurrentPageSize)
                .Take(CurrentPageSize);
        }

        private IEnumerable<Item> FilterItems()
        {
            IEnumerable<Item> items = FilterItemsByCategory(_items);
            items = FilterItemsByPrice(items);
            items = SortingItems(items);
            return items;
        }

        private IEnumerable<Item> FilterItemsByCategory(IEnumerable<Item> items)
        {
            if (CurrentCategory != null)
            {
                return items.Where(p => p.Category == CurrentCategory);
            }
            return items;
        }

        private IEnumerable<Item> FilterItemsByPrice(IEnumerable<Item> items)
        {
            if (CurrentMinPrice != null)
            {
                items = items.Where(p => p.Price > CurrentMinPrice);
            }
            if (CurrentMaxPrice != null)
            {
                items = items.Where(p => p.Price < CurrentMaxPrice);
            }
            return items;
        }

        private IEnumerable<Item> SortingItems(IEnumerable<Item> items)
        {
            switch (CurrentSortingType)
            {
                case "name":
                    return items.OrderBy(p => p.Name);
                case "price":
                    return items.OrderBy(p => p.Price);
                case "weight":
                    return items.OrderBy(p => p.Weight);
                default:
                    return items;
            }
        }

        protected string GetPagerLink(int i)
        {
            string path = RouteTable.Routes.GetVirtualPath(null, null,
                    new RouteValueDictionary()
                    {
                        {
                            "category", CurrentCategory
                        },
                        {
                            "page", i
                        },
                        {
                            "sorting", CurrentSortingType
                        },
                        {
                            "minPrice", CurrentMinPrice
                        },
                        {
                            "maxPrice", CurrentMaxPrice
                        },
                        {
                            "pageSize", CurrentPageSize
                        }
                    }).VirtualPath;
            return path;
        }

        protected string GetAdminLink()
        {
            return RouteTable.Routes.GetVirtualPath(null, "admin_orders", null).VirtualPath;
        }

        public string ShortenString(string str)
        {
            int startIndex = 40;
            if (str.Length > startIndex)
            {
                str = str.Remove(startIndex);
                str += "...";
            }
            return str;

        }

        protected void PriceSortingButton_Click(object sender, EventArgs e)
        {
            string minPrice = Request.Form["MinPriceTextBox"] ?? "";
            string maxPrice = Request.Form["MaxPriceTextBox"] ?? "";
            string path = RouteTable.Routes.GetVirtualPath(null, null,
                new RouteValueDictionary()
                {
                    {
                        "category", CurrentCategory
                    },
                    {
                        "page", CurrentPage
                    },
                    {
                        "minPrice", minPrice
                    },
                    {
                        "maxPrice", maxPrice
                    },
                    {
                        "pageSize", CurrentPageSize
                    }
                }).VirtualPath;
            Response.Redirect(path);
        }
    }
}