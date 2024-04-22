using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LandfillServices.UI.Web.UI
{
    public partial class BrokerCommissionsForAccounting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                FillValues();
            }
        }
        protected void ButtonSelect_Click(object sender, EventArgs e)
        {
            decimal sumAmount = 0;

            foreach (GridViewRow row in GridViewCommissions.Rows)
            {
                // Access the CheckBox
                CheckBox cb = (CheckBox)row.FindControl("chkSelect");
                if (cb != null && cb.Checked)
                {
                    int commissionID = Convert.ToInt32(GridViewCommissions.DataKeys[row.RowIndex].Value);

                    ObjectsFunctions.BrokerPaymentCommission commission = ControllerFunctions.BrokerPaymentCommissionController.SearchByID(commissionID);

                    if (commission != null)
                    {
                        sumAmount += commission.Amount;

                        ObjectsFunctions.BrokerAccounting brokerAccounting = ControllerFunctions.BrokerAccountingController.SearchForAgregate(commission.BrokerPassageProduct.ContractsBroker.BrokerID);
                        if (brokerAccounting != null)
                        {
                            commission.BrokerAccountingID = brokerAccounting.ID;
                            commission.PaymentDate = DateTime.Now.Date;
                            ControllerFunctions.BrokerPaymentCommissionController.Save(commission);
                        }
                        else
                        {
                            var newbrokerAccounting = new ObjectsFunctions.BrokerAccounting();
                            newbrokerAccounting.BrokerID = commission.BrokerPassageProduct.ContractsBroker.BrokerID;
                            ControllerFunctions.BrokerAccountingController.Save(newbrokerAccounting);

                            commission.BrokerAccountingID = newbrokerAccounting.ID;
                            commission.PaymentDate = DateTime.Now.Date;
                            ControllerFunctions.BrokerPaymentCommissionController.Save(commission);
                        }

                    }
                }
            }

            clearSelectedCommissionIndex();

            GridViewCommissions.DataSource = getDatasource();
            GridViewCommissions.PageIndex = 0;
            databind();
        }

        protected void GridViewCommissions_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkBox = e.Row.FindControl("chkSelect") as CheckBox;

            }
        }

        private void clearSelectedCommissionIndex()
        {
            for (int i = SelectedCommissionIndex.Count() - 1; i >= 0; i--)
                SelectedCommissionIndex.Remove(i);


        }


        private decimal MontantTotalSelected()
        {
            for (int i = 0; i <= SelectedCommissionIndex.Count(); i++)
                SelectedCommissionIndex.Add(i);

            return 0;

        }

        protected void GridViewCommissions_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.SetRenderMethodDelegate(RenderHeader);
                AddSortImage(e.Row);
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowState == DataControlRowState.Normal)
                {
                    e.Row.Attributes.Add("onmouseover", "this.className='gridRowOver'");
                    e.Row.Attributes.Add("onmouseout", "this.className='gridRow'");
                }
                else if (e.Row.RowState == DataControlRowState.Alternate)
                {
                    e.Row.Attributes.Add("onmouseover", "this.className='gridRowOver'");
                    e.Row.Attributes.Add("onmouseout", "this.className='gridAlternatingRow'");
                }
            }
        }

        private void RenderHeader(HtmlTextWriter output, Control container)
        {
            for (int i = 0; i < container.Controls.Count; i++)
            {
                TableCell cell = (TableCell)container.Controls[i];
                //stretch non merged columns for two rows
                if (!info.MergedColumns.Contains(i))
                {
                    cell.Attributes["rowspan"] = "2";
                    cell.RenderControl(output);
                }
                else //render merged columns common title
                    if (info.StartColumns.Contains(i))
                {
                    output.Write(string.Format("<th align='center' colspan='{0}'>{1}</th>",
                             info.StartColumns[i], info.Titles[i]));
                }
            }

            //close the first row	
            output.RenderEndTag();
            //set attributes for the second row
            GridViewCommissions.HeaderStyle.AddAttributesToRender(output);
            //start the second row
            output.RenderBeginTag("tr");

            //render the second row (only the merged columns)
            for (int i = 0; i < info.MergedColumns.Count; i++)
            {
                TableCell cell = (TableCell)container.Controls[info.MergedColumns[i]];
                cell.RenderControl(output);
            }
        }


        private ObjectsFunctions.MergedColumnsInfo info
        {
            get
            {
                if (ViewState["info"] == null)
                    ViewState["info"] = new ObjectsFunctions.MergedColumnsInfo();
                return (ObjectsFunctions.MergedColumnsInfo)ViewState["info"];
            }
        }

        protected void AddSortImage(GridViewRow headerRow)
        {
            int selCol = GetSortColumnIndex(SortExpression);

            if (-1 == selCol)
            {
                return;
            }

            // Create the sorting image based on the sort direction
            Image sortImage = new Image();

            if (SortDirection.Ascending == SortDirection)
            {
                sortImage.ImageUrl = "/Medias/Pictures/up.png";
                sortImage.AlternateText = "Ascendant";
            }
            else
            {
                sortImage.ImageUrl = "/Medias/Pictures/down.png";
                sortImage.AlternateText = "Descendant";
            }

            // Add the image to the appropriate header cell
            headerRow.Cells[selCol].Controls.Add(sortImage);
        }

        // This is a helper method used to determine the index of the
        // column being sorted. If no column is being sorted, -1 is returned.
        protected int GetSortColumnIndex(String strCol)
        {
            foreach (DataControlField field in this.GridViewCommissions.Columns)
            {
                if (field.SortExpression == strCol)
                    return GridViewCommissions.Columns.IndexOf(field);
            }

            return -1;
        }


        protected void GridViewCommissions_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (e.SortExpression.Equals(this.SortExpression) && this.SortDirection.Equals(SortDirection.Ascending))
                this.SortDirection = System.Web.UI.WebControls.SortDirection.Descending;
            else
                this.SortDirection = System.Web.UI.WebControls.SortDirection.Ascending;
            this.SortExpression = e.SortExpression;

            GridViewCommissions.DataSource = getDatasource();
            GridViewCommissions.PageIndex = 0;
            databind();
        }

        private void RemoveRowIndex(int index)
        {
            SelectedCommissionIndex.Remove(index);
        }

        private void PersistRowIndex(int index)
        {
            if (!SelectedCommissionIndex.Exists(i => i == index))
                SelectedCommissionIndex.Add(index);
        }

        private List<Int32> SelectedCommissionIndex
        {
            get
            {
                if (ViewState["SelectedCommissionIndex"] == null)
                    ViewState["SelectedCommissionIndex"] = new List<Int32>();

                return (List<Int32>)ViewState["SelectedCommissionIndex"];
            }
        }

        private void RePopulateCheckBoxes()
        {
            foreach (GridViewRow row in GridViewCommissions.Rows)
            {
                var chkBox = row.FindControl("chkSelect") as CheckBox;

                IDataItemContainer container = (IDataItemContainer)chkBox.NamingContainer;

                if (SelectedCommissionIndex != null)
                {
                    if (SelectedCommissionIndex.Exists(i => i == container.DataItemIndex))
                        chkBox.Checked = true;
                }
            }
        }


        private void checkMarquerEnvoi(CheckBox chkBox)
        {
            IDataItemContainer container = (IDataItemContainer)chkBox.NamingContainer;

            if (chkBox.Checked)
                PersistRowIndex(container.DataItemIndex);
            else
                RemoveRowIndex(container.DataItemIndex);
        }


        protected void chkAllSelect_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk;
            foreach (GridViewRow rowItem in GridViewCommissions.Rows)
            {
                chk = (CheckBox)(rowItem.Cells[0].FindControl("chkSelect"));
                chk.Checked = ((CheckBox)sender).Checked;
                checkMarquerEnvoi(chk);
            }
        }
        protected void setPage(Object src, CommandEventArgs e)
        {
            foreach (GridViewRow row in GridViewCommissions.Rows)
            {
                var chkBox = row.FindControl("chkSelect") as CheckBox;
                checkMarquerEnvoi(chkBox);
            }

            GridViewCommissions.DataSource = getDatasource(); ;

            // used by custom paging UI
            switch (e.CommandName)
            {
                case ("first"):
                    GridViewCommissions.PageIndex = 0;
                    break;
                case ("prev"):
                    if (GridViewCommissions.PageIndex > 0)
                        GridViewCommissions.PageIndex--;
                    break;
                case ("next"):
                    if (GridViewCommissions.PageIndex < (GridViewCommissions.PageCount - 1))
                        GridViewCommissions.PageIndex++;
                    break;
                case ("last"):
                    GridViewCommissions.PageIndex = (GridViewCommissions.PageCount - 1);
                    break;
            }
            databind();
        }


        private List<ObjectsFunctions.BrokerPaymentCommission> getDatasource()
        {
            List<ObjectsFunctions.BrokerPaymentCommission> bllCommissionList = ControllerFunctions.BrokerPaymentCommissionController.SearchToAccounting();

            return bllCommissionList.ToList();
        }


        private void databind()
        {
            GridViewCommissions.DataBind();
            // getPage(null, null);
            RePopulateCheckBoxes();
        }
         
        public void FillValues()
        {

            GridViewCommissions.DataSource = getDatasource();
            GridViewCommissions.PageIndex = 0;
            databind();

        }


        public int PageSize
        {
            get
            {
                return GridViewCommissions.PageSize;
            }
            set
            {
                GridViewCommissions.PageSize = value;
            }
        }


        public SortDirection SortDirection
        {
            get
            {
                if (ViewState["SortDirection"] != null)
                    return (SortDirection)ViewState["SortDirection"];
                return SortDirection.Ascending;
            }
            set
            {
                ViewState["SortDirection"] = value;
            }
        }

        public string SortExpression
        {
            get
            {
                if (ViewState["SortExpression"] != null)
                    return ViewState["SortExpression"].ToString();
                return null;
            }
            set
            {
                ViewState["SortExpression"] = value;
            }
        }
    }
}