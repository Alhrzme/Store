using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Store.Models;
using System.Web.ModelBinding;

namespace Store.Pages.Admin
{
    public partial class AddingItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Item newItem = new Item();
            if (TryUpdateModel(newItem, new FormValueProvider(ModelBindingExecutionContext)))
            {
                if (ItemImage.PostedFile != null)
                {
                    HttpPostedFile image = ItemImage.PostedFile;
                    byte[] Data = new byte[image.ContentLength];
                    image.InputStream.Read(Data, 0, image.ContentLength);
                    newItem.Image = Data;
                    ItemsDB.AddNewItem(newItem);
                    Label1.Text = "Новый товар добавлен";
                }
            }
        }
    }
}