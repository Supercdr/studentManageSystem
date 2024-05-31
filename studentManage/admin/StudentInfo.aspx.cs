using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace studentManage.admin
{
    public partial class StudentInfo : System.Web.UI.Page
    {
        public SDM.BLL.StudentsInfo bll = new SDM.BLL.StudentsInfo();
        public SDM.Model.StudentInfo model = new SDM.Model.StudentInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }
        public void LoadData()
        {
            gdvWishList.DataSource = bll.GetListByPage("1=1", "UserID ASC", AspNetPager1.PageSize * (AspNetPager1.CurrentPageIndex - 1) + 1,
                AspNetPager1.PageSize * AspNetPager1.CurrentPageIndex);
            gdvWishList.DataKeyNames = new string[]{ "UserID"};
            gdvWishList.DataBind();
            AspNetPager1.RecordCount = bll.GetRecordCount("1=1");
        }

        protected void gdvWishList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                e.Row.Cells[1].Text = id.ToString();
            }
        }

        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            LoadData();
        }

        protected void btnSearchByName_Click(object sender, EventArgs e)
        {
            gdvWishList.DataSource = bll.GetStudentListByUserName("%" + txtUserNameSearch.Text.Trim() + "%");
            gdvWishList.DataBind();
        }

        protected void btnSearchByXy_Click(object sender, EventArgs e)
        {
            gdvWishList.DataSource = bll.GetStudentListByUserXy("%" + txtUserXySearch.Text.Trim() + "%");
            gdvWishList.DataBind();
        }

        protected void btnShowAll_Click(object sender,EventArgs e)
        {
            LoadData();
        }

        protected void btnCancle_Click(object sender, EventArgs e)
        {
            this.CheckBox1.Checked = false;
            for(int i = 0; i <= gdvWishList.Rows.Count - 1; i++)
            {
                CheckBox cbox = (CheckBox)gdvWishList.Rows[i].FindControl("ChkSelected");
                cbox.Checked = false;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            for(int i = 0; i <= gdvWishList.Rows.Count - 1; i++)
            {
                CheckBox cbox = (CheckBox)gdvWishList.Rows[i].FindControl("ChkSelected");
                if (cbox.Checked == true)
                {
                    bll.Delete(Convert.ToInt32(gdvWishList.DataKeys[i].Value));
                }
            }
            LoadData();
            this.CheckBox1.Checked = false;
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i <= gdvWishList.Rows.Count - 1; i++)
            {
                CheckBox cbox = (CheckBox)gdvWishList.Rows[i].FindControl("ChkSelected");
                if (CheckBox1.Checked == true)
                {
                    cbox.Checked = true;
                }
                else
                {
                    cbox.Checked = false;
                }
            }
        }
    }
}