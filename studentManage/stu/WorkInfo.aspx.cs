using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace studentManage.stu
{
    public partial class WorkInfo : System.Web.UI.Page
    {
        public SDM.BLL.WorksInfo bll = new SDM.BLL.WorksInfo();
        public SDM.Model.WorksInfo model = new SDM.Model.WorksInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                switch (Request.QueryString["action"].ToString())
                {
                    case "Add":
                        txtWorkTime.Text = Convert.ToString(DateTime.Now.ToString());
                        break;
                    case "Check":
                        btnOK.Text = "作品上传成功，只能查看，不能修改！！";
                        btnOK.Enabled = false;
                        btnUploadVideo.Enabled = false;
                        btnUploadVideo.Text = "禁止上传";
                        btnUploadPic.Enabled = false;
                        btnUploadPic.Text = "禁止上传";
                        int id = int.Parse(Request.QueryString["id"]);
                        model = bll.GetModel(id);
                        WorkContent.Value = model.WorkDes.ToString();
                        txtWorkName.Text = model.WorkName.ToString();
                        txtWorkTime.Text = Convert.ToString(model.WorkTime.ToString());
                        txtWorkVideoUrl.Text = model.WorkUrl.ToString();
                        txtWorkPicUrl.Text = model.WorkPicUrl.ToString();
                        imgsrc.ImageUrl = txtWorkPicUrl.Text.Trim();
                        break;
                }
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            if (txtWorkName.Text == "" || WorkContent.Value == "" || txtWorkVideoUrl.Text == "")
            {
                SDM.DAL.ShowInfo.Alert("作品名称||作品描述||作品视频为必填项！！", this.Page);
                return;
            }
            else
            {
                try
                {
                    int result = bll.Add(CreateModel());
                    if (result != 0)
                    {
                        SDM.DAL.ShowInfo.Alert("操作成功！", this.Page);
                        txtWorkVideoUrl.Text = "";
                        txtWorkName.Text = "";
                        WorkContent.Value = "";
                        txtWorkPicUrl.Text = "";
                        txtWorkVideoUrl.Text = "";
                        imgsrc.ImageUrl = null;
                    }
                    else
                    {
                        SDM.DAL.ShowInfo.Alert("操作失败，添加作品失败！", this.Page);
                    }
                }
                catch (Exception ex)
                {
                    SDM.DAL.ShowInfo.Alert("插入数据库失败！", this.Page);
                    Response.Write(ex);
                }
            }
        }
        public SDM.Model.WorksInfo CreateModel()
        {
            model.UserID = int.Parse(Session["userid"].ToString());
            model.WorkCate = "个人作品";
            model.WorkDes = WorkContent.Value.Trim();
            model.WorkName = txtWorkName.Text.Trim();
            model.WorkTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
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
    }
}