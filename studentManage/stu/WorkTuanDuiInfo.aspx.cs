using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace studentManage.stu
{
    public partial class WorkTuanDuiInfo : System.Web.UI.Page
    {
        public SDM.BLL.WorkTuanDui bll = new SDM.BLL.WorkTuanDui();
        public SDM.Model.WorkTuanDui model = new SDM.Model.WorkTuanDui();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null || Session["username"].ToString() == "")
            {
                SDM.DAL.ShowInfo.Alert("请登录！", this.Page);
                Response.Redirect("index.aspx");
            }
            else
            {
                switch (Request.QueryString["action"].ToString().Trim())
                {
                    case "Add":
                        txtWorkTime.Text = Convert.ToString(DateTime.Now.ToString());
                        txtUser1.Text = Session["username"].ToString().Trim();
                        txtUser1ID.Text = Session["usernumber"].ToString().Trim();
                        break;
                    case "Check":
                        int id = int.Parse(Request.QueryString["id"]);
                        model = bll.GetModel(id);
                        txttdmc.Text = model.tdmc.ToString();
                        txtUser1ID.Text = Convert.ToString(model.UserID_1.ToString());
                        txtUser1Des.Text = model.UserID_1_des.ToString();
                        txtUser2ID.Text = Convert.ToString(model.UserID_2.ToString());
                        txtUser2Des.Text = model.UserID_2_des.ToString();
                        txtUser3ID.Text = Convert.ToString(model.UserID_3.ToString());
                        txtUser3Des.Text = model.UserID_3_des.ToString();
                        WorkContent.Value = model.WorkDes.ToString();
                        txtWorkName.Text = model.WorkName.ToString();
                        txtWorkVideoUrl.Text = model.WorkUrl.ToString();
                        txtWorkTime.Text = Convert.ToString(model.WorkTime.ToString());
                        imgsrc.ImageUrl = txtWorkPicUrl.Text;
                        btnOK.Enabled = false;
                        btnOK.Text = "您无权限提交信息";
                        btnUploadVideo.Enabled = false;
                        btnUploadVideo.Text = "禁止上传";
                        btnUploadPic.Enabled = false;
                        btnUploadPic.Text = "禁止上传";
                        break;
                }

            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            if (txttdmc.Text == "" || txtUser1ID.Text == "" || txtUser2ID.Text == ""
                || WorkContent.Value == "" || txtWorkName.Text == "" || txtWorkVideoUrl.Text == "")
            {
                SDM.DAL.ShowInfo.Alert("团队名称，团队成员，作品描述，作品名称必填!", this.Page);
                return;
            }
            else
            {
                try
                {
                    bll.Add(CreateModel());
                    SDM.DAL.ShowInfo.Alert("添加作品成功!!", this.Page);
                    txttdmc.Text = "";
                    txtWorkVideoUrl.Text = "";
                    txtWorkName.Text = "";
                    WorkContent.Value = "";
                    txtWorkPicUrl.Text = "";
                    txtWorkVideoUrl.Text = "";
                    txtUser2.Text = "";
                    txtUser2ID.Text = "";
                    txtUser2Des.Text = "";
                    txtUser3.Text = "";
                    txtUser3ID.Text = "";
                    txtUser3Des.Text = "";

                }
                catch (Exception ex)
                {
                    SDM.DAL.ShowInfo.Alert("添加作品发生异常!", this.Page);
                    Response.Write(ex);
                }
            }
        }
        private int GetNextWorkID()
        {
            string sql = "select max(WorkID) from WorkTuanDui";
            object result = SDM.DAL.DbHelperSQL.GetSingle(sql);
            if (result != DBNull.Value && result != null)
            {
                return Convert.ToInt32(result) + 1;
            }
            else
            {
                return 1;
            }
        }

        public SDM.Model.WorkTuanDui CreateModel()
        {
            model.WorkID = GetNextWorkID();
            model.tdmc = txttdmc.Text.Trim();
            model.UserID_1 = Convert.ToInt32(txtUser1ID.Text.Trim());
            model.UserID_1_des = txtUser1Des.Text.Trim();
            model.UserID_2 = Convert.ToInt32(txtUser2ID.Text.Trim());
            model.UserID_2_des = txtUser2Des.Text.Trim();
            model.UserID_3 = Convert.ToInt32(txtUser3ID.Text.Trim());
            model.UserID_3_des = txtUser3Des.Text.Trim();
            model.WorkCate = "团队作品";
            model.WorkDes = WorkContent.Value.Trim();
            model.WorkName = txtWorkName.Text.Trim();
            model.WorkTime = Convert.ToString(DateTime.Now.ToString());
            model.WorkUrl = txtWorkVideoUrl.Text.Trim();
            model.WorkPicUrl = txtWorkPicUrl.Text.Trim();
            return model;
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
                    string serverPath = Server.MapPath("/uploadfiles/zuoye/") + filename;

                    // 确保上传目录存在
                    string directoryPath = Server.MapPath("/uploadfiles/zuoye/");
                    if (!System.IO.Directory.Exists(directoryPath))
                    {
                        System.IO.Directory.CreateDirectory(directoryPath);
                    }

                    FileUploadVideo.PostedFile.SaveAs(serverPath);
                    SDM.DAL.ShowInfo.Alert("上传成功！", this.Page);
                    this.txtWorkVideoUrl.Text = "/uploadfiles/zuoye/" + filename;
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
                        SDM.DAL.ShowInfo.Alert("视频文件格式错误，只能上传：jpg,gif或者png格式！！", this.Page);
                    }
                }
            }
            catch (Exception ex)
            {
                SDM.DAL.ShowInfo.Alert("上传发生错误，请检查文件类型是否正确！！！错误信息：{ex.Message}", this.Page);
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

        protected void btnSearch3_Click(object sender, EventArgs e)
        {
            if (txtUser3.Text == "")
            {
                SDM.DAL.ShowInfo.Alert("请输入团队成员姓名！", this.Page);
                return;
            }
            else if (bll.Exists(txtUser3.Text.Trim()))
            {
                txtUser3ID.Text = Convert.ToString(bll.GetUserIDByUserName(txtUser3.Text.Trim()).Tables["ds"].Rows[0][0].ToString());

            }
            else
            {
                SDM.DAL.ShowInfo.Alert("当前成员不存在，请联系管理员添加此成员！！", this.Page);
                //获取团队成员1的UserID值。
                return;
            }
        }

        protected void btnSearch1_Click(object sender, EventArgs e)
        {
            if (txtUser1.Text == "")
            {
                SDM.DAL.ShowInfo.Alert("请输入团队成员姓名！", this.Page);
                return;
            }
            else if (bll.Exists(txtUser1.Text.Trim()))
            {
                txtUser1ID.Text = Convert.ToString(bll.GetUserIDByUserName(txtUser1.Text.Trim()).Tables["ds"].Rows[0][0].ToString());

            }
            else
            {
                SDM.DAL.ShowInfo.Alert("当前成员不存在，请联系管理员添加此成员！！", this.Page);
                //获取团队成员1的UserID值。
                return;
            }
        }

        protected void btnSearch2_Click(object sender, EventArgs e)
        {
            if (txtUser2.Text == "")
            {
                SDM.DAL.ShowInfo.Alert("请输入团队成员姓名！", this.Page);
                return;
            }
            else if (bll.Exists(txtUser2.Text.Trim()))
            {
                txtUser2ID.Text = Convert.ToString(bll.GetUserIDByUserName(txtUser2.Text.Trim()).Tables["ds"].Rows[0][0].ToString());

            }
            else
            {
                SDM.DAL.ShowInfo.Alert("当前成员不存在，请联系管理员添加此成员！！", this.Page);
                //获取团队成员1的UserID值。
                return;
            }
        }
    }
}