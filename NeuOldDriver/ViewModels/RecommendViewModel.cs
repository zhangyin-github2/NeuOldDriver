using System.Linq;
using System.Collections.Generic;

using NeuOldDriver.Models;

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
                    Text ="计算机体系专题", Major="计算机科学与技术", Category="新知识", Term="四年级第一学期", Rating=5
                },
                new CourseData() {
                    Text="普适计算导论", Major="计算机科学与技术" , Category="新知识", Term="四年级第一学期", Rating=5
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
                    Text="嵌入式实时系统", Major="计算机科学与技术" , Category="专题选修", Term="四年级第一学期", Rating=0
                },
                new CourseData() {
                    Text="软件技术专题", Major="计算机科学与技术" , Category="新知识", Term="四年级第一学期", Rating=5
                },
                new CourseData() {
                    Text="互联网计算概论", Major="计算机科学与技术" , Category="新知识", Term="四年级第一学期", Rating=5
                },
                new CourseData() {
                    Text="计算机网络技术", Major="计算机科学与技术" , Category="专题选修", Term="四年级第一学期", Rating=5
                }
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
            private set { items = value; OnPropertyChanged(nameof(Items)); }
        }

        public void Reset() {
            Items = classes;
        }

        public void FilterBy(string propname, int index) {
            Items = items.Where((item) => {
                if (index == 0)
                    return true;
                return (string)item[propname] == props[propname][index];
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
