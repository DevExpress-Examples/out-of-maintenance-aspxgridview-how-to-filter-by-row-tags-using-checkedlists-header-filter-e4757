using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxGridView;

public partial class _Default : System.Web.UI.Page {
    protected void gvOrders_CustomUnboundColumnData(object sender, ASPxGridViewColumnDataEventArgs e) {
        if (e.Column.FieldName == "CustomDescription") {
            string description = Convert.ToString(e.GetListSourceFieldValue("Description"));
            string[] items = description.Split(';');
            for (int i = 0; i < items.Length; i++) {
                items[i] = String.Format("#{0}#", items[i]); //Wrap items with '#'
            }
            e.Value = String.Join(";", items);
        }
    }

    protected void gvOrders_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e) {
        if (e.Column.FieldName == "CustomDescription") {
            string description = Convert.ToString(e.Value);
            string[] items = description.Split(';');
            for (int i = 0; i < items.Length; i++) {
                string item = items[i];
                items[i] = item.Substring(1, item.Length - 2);
            }
            e.DisplayText = String.Join(", ", items); //Remove '#' to display values
        }
    }

    protected void gvOrders_HeaderFilterFillItems(object sender, ASPxGridViewHeaderFilterEventArgs e) {
        if (e.Column.FieldName == "CustomDescription") {
            List<string> exsistingNewValues = new List<string>();
            List<FilterValue> newValues = new List<FilterValue>();
            foreach (FilterValue value in e.Values) {
                string description = value.Value;
                string[] items = description.Split(';');
                foreach (string item in items) {
                    if (!exsistingNewValues.Contains(item)) {
                        exsistingNewValues.Add(item);

                        FilterValue newValue = new FilterValue();
                        newValue.DisplayText = item.Substring(1, item.Length - 2);
                        newValue.Query = String.Format("Contains([{0}], '{1}')", e.Column.FieldName, item);
                        newValues.Add(newValue);
                    }
                }
            }
            e.Values.Clear();
            e.Values.AddRange(newValues);
        }
    }
}