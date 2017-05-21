using System;
using Xamarin.Forms;

namespace ProjectAccounting
{
    public class Validations : TriggerAction<Entry>
    {
        protected override void Invoke(Entry entry)
        {
            //if (entry.Text != "")
            //{
            //    entry.Text = "";
            //    entry.Placeholder = "You must specify a valid project!";
            //}
        }
    }
}


