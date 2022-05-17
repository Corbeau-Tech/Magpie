using System;
using SQLite;

namespace MagpieProject.Models
{
	[Table("ProjectDetails")]
	public class ProjectModel: BaseModel
    {
		[PrimaryKey]
		public string ID { get; set; }
		public string ProjectID { get; set; }
		public string ProjectCode { get; set; }
		public string ProjectName { get; set; }
		[Column("PorjectDescription")]
		public string Description { get; set; }
		public string ProjectShortDescription { get; set; }
		public string CurrencyID { get; set; }
		public string CurrencyCode { get; set; }
		public string BUID { get; set; }
		public string RegionID { get; set; }
		public string Status { get; set; }
		public DateTime BaselineStartDate { get; set; }
		public DateTime BaselineEndDate { get; set; }
		public DateTime ForecastStartdate { get; set; }
		public DateTime ForecastEnddate { get; set; }
		public DateTime ActualStartdate { get; set; }
		public DateTime ActualEnddate { get; set; }
		public string BaselineDuration { get; set; }
		public string ForecastDuration { get; set; }
		public string ActualDuration { get; set; }
		public string BaselineWork { get; set; }
		public DateTime StatusChangeDate { get; set; }
		public string Trend { get; set; }
		public DateTime TrendSetDate { get; set; }
		public string TotalBudget { get; set; }
		public string ActualCost { get; set; }
		public string BudgetProjectiontext { get; set; }
		public string CostProjectiontext { get; set; }
		public string Percentage { get; set; }
		public string CurrentSliceNum { get; set; }
		public string BufferRemaining { get; set; }
		public bool IsActive { get; set; }
		public bool IsDeleted { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime ModifiedDate { get; set; }
		public string CreatedBy { get; set; }
		public string ModifiedBy { get; set; }
		public string version { get; set; }
		public string Remarks { get; set; }
		public string RangeValue { get; set; }
		public string RAGStatus { get; set; }

		private bool _IsSelected;
		[Ignore]
		public bool IsSelected
		{
			get
			{
				return _IsSelected;
			}
			set
			{
				_IsSelected = value;
				OnPropertyChanged();
			}
		}

		[Ignore]
		public int TempSequence { get; set; }

		private bool _isBeingDragged;
		[Ignore]
		public bool IsBeingDragged
		{
			get { return _isBeingDragged; }
			set
			{
				_isBeingDragged = value;
				OnPropertyChanged(nameof(IsBeingDragged));
			}
		}

		private bool _isBeingDraggedOver;
		[Ignore]
		public bool IsBeingDraggedOver
		{
			get { return _isBeingDraggedOver; }
			set
			{
				_isBeingDraggedOver = value;
				OnPropertyChanged(nameof(IsBeingDraggedOver));
			}
		}
	}
}
