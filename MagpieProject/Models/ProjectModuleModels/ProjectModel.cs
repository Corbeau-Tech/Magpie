//using System;
//using SQLite;

//namespace MagpieProject.Models.ProjectModuleModels
//{
//    [Table("Project")]
//    public class ProjectModel : BaseModel
//    {
       
//        private bool _IsSelected;
//        [Ignore]
//        public bool IsSelected
//        {
//            get
//            {
//                return _IsSelected;
//            }
//            set
//            {
//                _IsSelected = value;
//                OnPropertyChanged();
//            }
//        }

//        public string ProjectName { get; set; }
//        [PrimaryKey]
//        public string ID { get; set; }

//        public string Description { get; set; }
//        public string RangeValue { get; set; }
//        public string RAGStatus { get; set; }
//        public string DETAILS { get; set; }
//        public string BASELINESTART { get; set; }
//        public string BASELINEEND { get; set; }
//        public string START { get; set; }
//        public string END { get; set; }
//        public string BASELINEDURATION { get; set; }
//        public string DURATION { get; set; }
//        public string BASELINEWORK { get; set; }
//        public string PROJECTLEAD { get; set; }
//        public string STATUSCHANGEDATE { get; set; }
//        public string STATUSCHANGESUMM { get; set; }
//        public string TREND { get; set; }
//        public string TOTALBUDGET { get; set; }
//        public string AC { get; set; }
//        public string COSTSUM { get; set; }
//        public string BUDGETPROJECTIONSUMM { get; set; }

//        public string REGIONNUM { get; set; }
//        public string PERCENTAC { get; set; }
//        public string BUFFERREMAINING { get; set; }
//        public string BU { get; set; }
//        public string CURRENCY { get; set; }
//        public bool ISACTIVE { get; set; }
//        [Ignore]
//        public int TempSequence { get; set; }

//        private bool _isBeingDragged;
//        [Ignore]
//        public bool IsBeingDragged
//        {
//            get { return _isBeingDragged; }
//            set
//            {
//                _isBeingDragged = value;
//                OnPropertyChanged(nameof(IsBeingDragged));
//            }
//        }

//        private bool _isBeingDraggedOver;
//        [Ignore]
//        public bool IsBeingDraggedOver
//        {
//            get { return _isBeingDraggedOver; }
//            set
//            {
//                _isBeingDraggedOver = value;
//                OnPropertyChanged(nameof(IsBeingDraggedOver));
//            }
//        }
//    }
//}
