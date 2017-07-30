using System.Linq;
using System.Collections.Generic;

using NeuOldDriver.Models;
using NeuOldDriver.Extensions;

namespace NeuOldDriver.ViewModels {

    public class RecommendViewModel : ViewModelBase {

        private IList<CourseData> classes;

        /// <summary>
        /// properties and corresponding values
        /// </summary>
        private IDictionary<string, IList<string>> props;

        private IEnumerable<CourseData> items;

        public RecommendViewModel() {
            classes = new List<CourseData>() {
                new CourseData() {
                    Text="生物信息学导论", Major="计算机科学与技术" , Category="新知识", Term="四年级第一学期", Rating=5
                },
                new CourseData() {
                    Text="网络新技术", Major="计算机科学与技术" , Category="新知识", Term="四年级第一学期", Rating=5
                },
                new CourseData() {
                    Text="服务计算概论", Major="计算机科学与技术" , Category="新知识", Term="四年级第一学期", Rating=5
                },
                new CourseData() {
                    Text ="计算机体系专题", Major="计算机科学与技术", Category="新知识", Term="四年级第一学期", Rating=5
                },
                new CourseData() {
                    Text="普适计算导论", Major="计算机科学与技术" , Category="新知识", Term="四年级第一学期", Rating=5
                },               
                new CourseData() {
                    Text="软件技术专题", Major="计算机科学与技术" , Category="新知识", Term="四年级第一学期", Rating=5
                },
                new CourseData() {
                    Text="互联网计算概论", Major="计算机科学与技术" , Category="新知识", Term="四年级第一学期", Rating=5
                },
                new CourseData() {
                    Text ="数据库管理系统实现技术", Major="计算机科学与技术" , Category="专题选修", Term="四年级第一学期", Rating=5
                },
                new CourseData() {
                    Text="数字信号处理", Major="电子信息工程" , Category="专题选修", Term="四年级第一学期", Rating=5
                },
                new CourseData() {
                    Text="Linux操作系统分析", Major="计算机科学与技术" , Category="专题选修", Term="四年级第一学期", Rating=5
                },
                new CourseData() {
                    Text="嵌入式实时系统（英语）", Major="计算机科学与技术" , Category="专题选修", Term="四年级第一学期", Rating=0
                },
                new CourseData() {
                    Text="计算机网络技术", Major="计算机科学与技术" , Category="专题选修", Term="四年级第一学期", Rating=5
                },
                
                new CourseData() {
                    Text="数字系统设计", Major="计算机科学与技术" , Category="专题选修", Term="四年级第一学期", Rating=5
                },
                new CourseData() {
                    Text="Java语言及程序设计", Major="计算机科学与技术" , Category="专题选修", Term="三年级第二学期", Rating=5
                },
                new CourseData() {
                    Text="嵌入式系统及其应用", Major="计算机科学与技术" , Category="专题选修", Term="四年级第一学期", Rating=5
                },
                new CourseData() {
                    Text="软件体系结构（双语）", Major="计算机科学与技术" , Category="专题选修", Term="四年级第一学期", Rating=5
                },
                new CourseData() {
                    Text="信息安全基础", Major="计算机科学与技术" , Category="专题选修", Term="三年级第二学期", Rating=5
                },
                new CourseData() {
                    Text="信息处理与机器翻译", Major="计算机科学与技术" , Category="专题选修", Term="四年级第一学期", Rating=5
                },
                new CourseData() {
                    Text="文本智能处理技术", Major="计算机科学与技术" , Category="专题选修", Term="三年级第二学期", Rating=5
                },
                new CourseData() {
                    Text="专业外语（计算机）", Major="计算机科学与技术" , Category="专题选修", Term="四年级第一学期", Rating=5
                },
                new CourseData() {
                    Text="数据库系统实践", Major="计算机科学与技术" , Category="专题选修", Term="四年级第一学期", Rating=5
                },
                new CourseData() {
                    Text="计算机图形学", Major="计算机科学与技术" , Category="专题选修", Term="三年级第一学期", Rating=5
                },
                new CourseData() {
                    Text="网络编程技术", Major="计算机科学与技术" , Category="专题选修", Term="三年级第二学期", Rating=5
                },
                new CourseData() {
                    Text="多媒体技术", Major="计算机科学与技术" , Category="专题选修", Term="四年级第一学期", Rating=5
                },
                new CourseData() {
                    Text="软件建模技术", Major="计算机科学与技术" , Category="专题选修", Term="四年级第一学期", Rating=5
                },
                new CourseData() {
                    Text="智能数据与知识工程", Major="计算机科学与技术" , Category="专题选修", Term="四年级第一学期", Rating=5
                },
                new CourseData() {
                    Text="互联网计算概论", Major="计算机科学与技术" , Category="专题选修", Term="四年级第一学期", Rating=5
                },
                new CourseData() {
                    Text="自动控制原理", Major="电子信息工程" , Category="专题选修", Term="四年级第一学期", Rating=5
                },
                new CourseData() {
                    Text="MATLAB语言与应用", Major="电子信息工程" , Category="专题选修", Term="三年级第二学期", Rating=5
                },
                new CourseData() {
                    Text="嵌入式实时操作系统", Major="电子信息工程" , Category="专题选修", Term="四年级第一学期", Rating=5
                },
                new CourseData() {
                    Text="现代检测技术及系统", Major="电子信息工程" , Category="专题选修", Term="四年级第一学期", Rating=5
                },
                new CourseData() {
                    Text="电路计算机辅助设计", Major="电子信息工程" , Category="专题选修", Term="四年级第一学期", Rating=5
                },
                new CourseData() {
                    Text="实时信号处理技术", Major="电子信息工程" , Category="专题选修", Term="三年级第二学期", Rating=5
                },
                new CourseData() {
                    Text="现代信号处理新方法", Major="电子信息工程" , Category="专题选修", Term="四年级第一学期", Rating=5
                },
                new CourseData() {
                    Text="通信电子线路", Major="电子信息工程" , Category="专题选修", Term="四年级第一学期", Rating=5
                },
                new CourseData() {
                    Text="神经网络原理及应用", Major="电子信息工程" , Category="新知识", Term="四年级第一学期", Rating=5
                },
                new CourseData() {
                    Text="RFID射频识别技术", Major="电子信息工程" , Category="新知识", Term="四年级第一学期", Rating=5
                },
                new CourseData() {
                    Text="电磁兼容与高速电路设计", Major="电子信息工程" , Category="新知识", Term="四年级第一学期", Rating=5
                },
                new CourseData() {
                    Text="现代汽车电子技术", Major="电子信息工程" , Category="新知识", Term="四年级第一学期", Rating=5
                },
                new CourseData() {
                    Text="现代通信新技术", Major="电子信息工程" , Category="新知识", Term="四年级第一学期", Rating=5
                },
                new CourseData() {
                    Text="基于FPGA的SOPC设计", Major="电子信息工程" , Category="新知识", Term="四年级第一学期", Rating=5
                },
                new CourseData() {
                    Text="移动网络及其技术", Major="电子信息工程" , Category="新知识", Term="四年级第一学期", Rating=5
                },
                new CourseData() {
                    Text="光纤通信原理", Major="电子信息工程" , Category="新知识", Term="四年级第一学期", Rating=5
                },
                new CourseData() {
                    Text="信息安全基础", Major="电子信息工程" , Category="新知识", Term="四年级第一学期", Rating=5
                },
                new CourseData() {
                    Text="多媒体技术", Major="电子信息工程" , Category="新知识", Term="四年级第一学期", Rating=5
                },
                new CourseData() {
                    Text="软件建模技术", Major="电子信息工程" , Category="新知识", Term="四年级第一学期", Rating=5
                },
                new CourseData() {
                    Text="超大规模集成电路（VLSI）设计与EDA工程概论", Major="电子信息工程" , Category="新知识", Term="四年级第一学期", Rating=5
                },
                new CourseData() {
                    Text="专用芯片（ASIC）设计导论", Major="电子信息工程" , Category="新知识", Term="四年级第一学期", Rating=5
                },
            };
            items = classes;
            props = new Dictionary<string, IList<string>>() {
                {"Category", new List<string>() { "-请选择课程所属分类-", "人文类选修", "专题选修", "新知识", "体育课" } },
                {"Major", new List<string>() { "-请选择课程所属专业-", "计算机科学与技术", "电子信息工程", "软件工程", "自动化", "物联网", "机械工程" } },
                {"Term", new List<string>() { "-请选择课程所属学期-","一年级第一学期","一年级第二学期","二年级第一学期","二年级第二学期","三年级第一学期","三年级第二学期","四年级第一学期"} }
            };
        }

        public IEnumerable<string> Category {
            get { return props["Category"]; }
        }
        public IEnumerable<string> Major {
            get { return props["Major"]; }
        }
        public IEnumerable<string> Term {
            get { return props["Term"]; }
        }

        public IEnumerable<CourseData> Items {
            get { return items; }
            private set { SetProperty(ref items, value); }
        }

        public void Reset() {
            Items = classes;
        }

        public void FilterBy(string propname, int index) {
            Items = items.Where((item) => {
                return index == 0 || 
                    item.GetValue<string>(propname) == props[propname][index];
            });
        }

        public void SortClasses(bool descending) {
            if (descending)
                Items = items.OrderByDescending(item => item.Rating);
            else
                Items = items.OrderBy(item => item.Rating);
        }

    }
}
