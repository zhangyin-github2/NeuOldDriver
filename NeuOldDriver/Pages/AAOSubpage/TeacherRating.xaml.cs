using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace NeuOldDriver.Pages.AAOSubPage {
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class TeacherRating : Page {
        public TeacherRating() {
            this.InitializeComponent();
        }


        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (tBlockKeyword.Text == "徐久强")
                this.word.Text = "徐久强       所任课程：计算机系统专题        推荐指数：⭐⭐⭐";
            if (tBlockKeyword.Text == "毕远国")
                this.word.Text = "毕远国       所任课程：网络新技术        推荐指数：⭐⭐⭐⭐";
            if (tBlockKeyword.Text == "聂铁铮")
                this.word.Text = "聂铁铮       所任课程：数据库管理系统实现技术        推荐指数：⭐⭐⭐";
            if (tBlockKeyword.Text == "魏阳杰")
                this.word.Text = "魏阳杰       所任课程：专业外语        推荐指数：⭐⭐⭐";
            if (tBlockKeyword.Text == "李芳芳")
                this.word.Text = "李芳芳       所任课程：数据库系统实践        推荐指数：⭐⭐";
            if (tBlockKeyword.Text == "刘铮")
                this.word.Text = "刘铮      所任课程：计算机网络技术       推荐指数：⭐";
            else
                this.word.Text = "未查询到您要查找的教师信息";

        }
    }
}


