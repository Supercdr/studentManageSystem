using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace studentManage.admin
{
    public partial class WorkTuanDuiInfo : System.Web.UI.Page
    {
        protected global::System.Web.UI.HtmlControls.HtmlTextArea WorkContent;
        public SDM.BLL.WorkTuanDui bll = new SDM.BLL.WorkTuanDui();
        public SDM.Model.WorkTuanDui model = new SDM.Model.WorkTuanDui();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] == null || Session["username"].ToString() == "")
                {
                    SDM.DAL.ShowInfo.AlertAndRedirect("请登录！", "login.aspx", this.Page);
                }
                else
                {
                    switch (Request.QueryString["action"].ToString().Trim())
                    {
                        case "AdminEdit":
                            int id = int.Parse(Request.QueryString["id"]);
                            model = bll.GetModel(id);
                            txttdmc.Text = model.tdmc.ToString();

                            txtUserID1.Text = Convert.ToString(model.UserID_1.ToString());
                            if (txtUserID1.Text != "")
                                txtUser1.Text = Convert.ToString(bll.queryUserName(model.UserID_1.ToString()).Tables["ds"].Rows[0][0]);
                            if (model.UserID_1_des == null || model.UserID_1_des.ToString() == "")
                            {
                                txtUserID1Des.Text = "无";
                            }
                            else
                            {
                                txtUserID1Des.Text = model.UserID_1_des.ToString();
                            }
                            
                            txtUserID2.Text = Convert.ToString(model.UserID_2.ToString());
                            if (txtUserID2.Text != "")
                                txtUser2.Text = Convert.ToString(bll.queryUserName(model.UserID_2.ToString()).Tables["ds"].Rows[0][0]);
                            if (model.UserID_2_des == null || model.UserID_2_des.ToString() == "")
                            {
                                txtUserID2Des.Text = "无";
                            }
                            else
                            {
                                txtUserID2Des.Text = model.UserID_2_des.ToString();
                            }

                            txtUserID3.Text = Convert.ToString(model.UserID_3.ToString());
                            if (txtUserID3.Text != "")
                                txtUser3.Text = Convert.ToString(bll.queryUserName(model.UserID_3.ToString()).Tables["ds"].Rows[0][0]);
                            if (model.UserID_3_des == null || model.UserID_3_des.ToString() == "")
                            {
                                txtUserID3Des.Text = "无";
                            }
                            else
                            {
                                txtUserID3Des.Text = model.UserID_3_des.ToString();
                            }
                            
                            WorkContent.Value = model.WorkDes.ToString();
                            txtWorkName.Text = model.WorkName.ToString();
                            txtWorkVideoUrl.Text = model.WorkUrl.ToString();
                            txtTime.Text = Convert.ToString(model.WorkTime.ToString());
                            txtWorkPicUrl.Text = model.WorkPicUrl.ToString();
                            imgsrc.ImageUrl = txtWorkPicUrl.Text;
                            break;
                    }
                }
            }
        }
        public SDM.Model.WorkTuanDui CreateModel()
        {
            int id = int.Parse(Request.QueryString["id"]);
            model.tdmc = txttdmc.Text.Trim();
            model.WorkID = id;
            model.WorkName = txtWorkName.Text.Trim();
            model.WorkTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            model.WorkUrl = txtWorkVideoUrl.Text.Trim();
            model.UserID_1 = Convert.ToInt32(txtUserID1.Text.Trim());
            model.UserID_1_des = txtUserID1Des.Text.Trim();
            model.UserID_2 = Convert.ToInt32(txtUserID2.Text.Trim());
            model.UserID_2_des = txtUserID2Des.Text.Trim();
            model.UserID_3 = Convert.ToInt32(txtUserID3.Text.Trim());
            model.UserID_3_des = txtUserID3Des.Text.Trim();
            model.WorkCate = "团队作品";
            model.WorkDes = WorkContent.Value.Trim(); /*WorkContent.Value.Replace("/", "").Replace("", "").Trim()*/
            model.WorkPicUrl = txtWorkPicUrl.Text.Trim();
            return model;
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (txttdmc.Text == "" || txtUserID1.Text == "" || txtUserID2.Text == "" || WorkContent.Value == "" || txtWorkName.Text == "" || txtWorkVideoUrl.Text == "")
            {
                SDM.DAL.ShowInfo.Alert("团队名称，团队成员ID，作品描述，作品名称必填！！", this.Page);
                return;
            }
            else
            {
                try
                {
                    bool result = bll.Update(CreateModel());
                    if (result)
                    {
                        SDM.DAL.ShowInfo.AlertAndRedirect("修改作品信息成功！", "WorkTuanDuiList.aspx", this.Page);
                    }
                    else
                    {
                        SDM.DAL.ShowInfo.Alert("修改作品信息失败！", this.Page);
                    }
                }
                catch
                {
                    SDM.DAL.ShowInfo.Alert("修改作品信息发生异常！", this.Page);
                }
            }
        }

        protected void BtnSearch1_Click(object sender, EventArgs e)
        {
            if (txtUser1.Text.Trim() == "")
            {
                SDM.DAL.ShowInfo.Alert("请输入团队成员姓名！", this.Page);
                return;
            }else if (bll.ExistUser(txtUser1.Text.Trim()))
            {
                txtUserID1.Text = Convert.ToString(bll.GetUserNumberByUserName(txtUser1.Text.Trim()).Tables["ds"].Rows[0][0].ToString());
            }
            else
            {
                SDM.DAL.ShowInfo.Alert("当前成员不存在，请联系管理员添加此成员！！", this.Page);
                return;
            }
        }

        protected void BtnSearch2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["id"]);
            if (txtUser2.Text.Trim() == "")
            {
                SDM.DAL.ShowInfo.Alert("请输入团队成员姓名！", this.Page);
                return;
            }
            else if (bll.ExistUser(txtUser2.Text.Trim()))
            {
                txtUserID2.Text = Convert.ToString(bll.GetUserNumberByUserName(txtUser2.Text.Trim()).Tables["ds"].Rows[0][0].ToString());
            }
            else
            {
                SDM.DAL.ShowInfo.Alert("当前成员不存在，请联系管理员添加此成员！！", this.Page);
                return;
            }
        }

        protected void BtnSearch3_Click(object sender, EventArgs e)
        {
            if (txtUser3.Text.Trim() == "")
            {
                SDM.DAL.ShowInfo.Alert("请输入团队成员姓名！", this.Page);
                return;
            }
            else if (bll.ExistUser(txtUser3.Text.Trim()))
            {
                txtUserID3.Text = Convert.ToString(bll.GetUserNumberByUserName(txtUser3.Text.Trim()).Tables["ds"].Rows[0][0].ToString());
            }
            else
            {
                SDM.DAL.ShowInfo.Alert("当前成员不存在，请联系管理员添加此成员！！", this.Page);
                return;
            }
        }

        protected void btnUploadVideo_Click(object sender, EventArgs e)
        {
            string[] VideoType = { ".mp4" };
            string filepath = FileUploadVideo.PostedFile.FileName;
            try
            {
                if (string.IsNullOrEmpty(filepath))
                {
                    SDM.DAL.ShowInfo.Alert("请选择文件！！", this.Page);
                    return;
                }

                if (IsAllowedExtension(filepath, VideoType))
                {
                    string filename = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + filepath.Substring(filepath.LastIndexOf("\\") + 1);
                    string serverPath = Server.MapPath("/uploadfiles/tuandui/") + filename;

                    // 确保上传目录存在
                    string directoryPath = Server.MapPath("/uploadfiles/tuandui/");
                    if (!System.IO.Directory.Exists(directoryPath))
                    {
                        System.IO.Directory.CreateDirectory(directoryPath);
                    }

                    FileUploadVideo.PostedFile.SaveAs(serverPath);
                    SDM.DAL.ShowInfo.Alert("上传成功！", this.Page);
                    this.txtWorkVideoUrl.Text = "/uploadfiles/tuandui/" + filename;
                }
                else
                {
                    SDM.DAL.ShowInfo.Alert("视频文件格式错误，只能上传：mp4格式！！", this.Page);
                }
            }
            catch (Exception ex)
            {
                SDM.DAL.ShowInfo.Alert($"上传发生错误，请检查文件类型是否正确！！！错误信息：{ex.Message}", this.Page);
            }
        }
        private static bool IsAllowedExtension(string upFilePath, string[] arrExtension)
        {
            string strExtension = "";
            if (upFilePath != string.Empty)
            {
                strExtension = upFilePath.Substring(upFilePath.LastIndexOf("."));
                for (int i = 0; i < arrExtension.Length; i++)
                {
                    if (strExtension.Equals(arrExtension[i]))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        protected void btnUploadPic_Click(object sender, EventArgs e)
        {
            string[] PicType = { ".jpg", ".gif", ".png" };
            string filepath = FileUploadPic.PostedFile.FileName;
            try
            {
                if (string.IsNullOrEmpty(filepath))
                {
                    SDM.DAL.ShowInfo.Alert("请选择文件！！", this.Page);
                    return;
                }
                else
                {
                    if (IsAllowedExtension(filepath, PicType))
                    {
                        string filename = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + filepath.Substring(filepath.LastIndexOf("\\") + 1);
                        string serverpath = Server.MapPath("/uploadfiles/pic/") + filename;
                        // 确保上传目录存在
                        string directoryPath = Server.MapPath("/uploadfiles/pic/");
                        if (!System.IO.Directory.Exists(directoryPath))
                        {
                            System.IO.Directory.CreateDirectory(directoryPath);
                        }
                        FileUploadPic.PostedFile.SaveAs(serverpath);
                        SDM.DAL.ShowInfo.Alert("上传成功", this.Page);
                        this.txtWorkPicUrl.Text = "/uploadfiles/pic/" + filename;
                        imgsrc.ImageUrl = txtWorkPicUrl.Text;
                    }
                    else
                    {
                        SDM.DAL.ShowInfo.Alert("图片文件格式错误，只能上传：jpg,gif或者png格式！！", this.Page);
                    }
                }
            }
            catch (Exception ex)
            {
                SDM.DAL.ShowInfo.Alert($"上传发生错误，请检查文件类型是否正确！！！错误信息：{ex.Message} ", this.Page);
            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("./WorkTuanDuiList.aspx");
        }
    }
}