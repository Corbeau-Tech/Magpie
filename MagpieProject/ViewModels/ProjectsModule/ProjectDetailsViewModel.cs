using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Input;
using Acr.UserDialogs;
using MagpieProject.Database;
using MagpieProject.Helper;
using MagpieProject.Models;
using MagpieProject.Views.ProjectsModule;
using Rg.Plugins.Popup.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MagpieProject.ViewModels.ProjectsModule
{
    public class ProjectDetailsViewModel : BaseViewModel
    {
        public INavigation navigation { get { return App.Current.MainPage.Navigation; } set { } }
        private string _ProjectTitle;

        public string ProjectTitle
        {
            get { return _ProjectTitle; }
            set
            {
                _ProjectTitle = value;
                OnPropertyChanged(nameof(ProjectTitle));
            }
        }
        private string _ProjectDesc;

        public string ProjectDesc
        {
            get { return _ProjectDesc; }
            set
            {
                _ProjectDesc = value;
                OnPropertyChanged(nameof(ProjectDesc));
            }
        }

        private bool _Is1YSelected;

        public bool Is1YSelected
        {
            get { return _Is1YSelected; }
            set
            {
                _Is1YSelected = value;
                if (value)
                {
                    ChangeCurrencyGraphData();
                }
                OnPropertyChanged();
            }
        }
        private bool _Is6MSelected;

        public bool Is6MSelected
        {
            get { return _Is6MSelected; }
            set
            {
                _Is6MSelected = value;
                if (value)
                {
                    ChangeCurrencyGraphData();
                }
                OnPropertyChanged();
            }
        }
        private bool _Is3MSelected;

        public bool Is3MSelected
        {
            get { return _Is3MSelected; }
            set
            {
                _Is3MSelected = value;
                if (value)
                {
                    ChangeCurrencyGraphData();
                }
                OnPropertyChanged();
            }
        }
        private bool _Is1MSelected;

        public bool Is1MSelected
        {
            get { return _Is1MSelected; }
            set
            {
                _Is1MSelected = value;
                if (value)
                {
                    ChangeCurrencyGraphData();
                }
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Model> _Data;

        public ObservableCollection<Model> Data
        {
            get { return _Data; }
            set
            {
                _Data = value;
                OnPropertyChanged(nameof(Data));
            }
        }
        private ObservableCollection<Model> _BudgetData;

        public ObservableCollection<Model> BudgetData
        {
            get { return _BudgetData; }
            set
            {
                _BudgetData = value;
                OnPropertyChanged(nameof(BudgetData));
            }
        }
        private ObservableCollection<Model> _DataForecast;

        public ObservableCollection<Model> DataForecast
        {
            get { return _DataForecast; }
            set
            {
                _DataForecast = value;
                OnPropertyChanged(nameof(DataForecast));
            }
        }

        private ObservableCollection<Model> _HealthProjectionData;

        public ObservableCollection<Model> HealthProjectionData
        {
            get { return _HealthProjectionData; }
            set
            {
                _HealthProjectionData = value;
                OnPropertyChanged(nameof(HealthProjectionData));
            }
        }

        private ObservableCollection<Model> _HealthProjectionDataForecast;

        public ObservableCollection<Model> HealthProjectionDataForecast
        {
            get { return _HealthProjectionDataForecast; }
            set
            {
                _HealthProjectionDataForecast = value;
                OnPropertyChanged(nameof(HealthProjectionDataForecast));
            }
        }

        private ObservableCollection<Model> _CurrencyData;

        public ObservableCollection<Model> CurrencyData
        {
            get { return _CurrencyData; }
            set
            {
                _CurrencyData = value;
                OnPropertyChanged(nameof(CurrencyData));
            }
        }

        private ObservableCollection<Model> _CurrencyBudgetData;

        public ObservableCollection<Model> CurrencyBudgetData
        {
            get { return _CurrencyBudgetData; }
            set
            {
                _CurrencyBudgetData = value;
                OnPropertyChanged(nameof(CurrencyBudgetData));
            }
        }

        private ObservableCollection<Model> _CurrencyForecastData;

        public ObservableCollection<Model> CurrencyForecastData
        {
            get { return _CurrencyForecastData; }
            set
            {
                _CurrencyForecastData = value;
                OnPropertyChanged(nameof(CurrencyForecastData));
            }
        }

        private ObservableCollection<ScoreDetailModel> _ScoreDetailList;

        public ObservableCollection<ScoreDetailModel> ScoreDetailList
        {
            get { return _ScoreDetailList; }
            set
            {
                _ScoreDetailList = value;
                OnPropertyChanged(nameof(ScoreDetailList));
            }
        }

        private DateTime _MinimumDate;

        public DateTime MinimumDate
        {
            get { return _MinimumDate; }
            set
            {
                _MinimumDate = value;
                OnPropertyChanged(nameof(MinimumDate));
            }
        }
        private DateTime _MaximumDate;

        public DateTime MaximumDate
        {
            get { return _MaximumDate; }
            set
            {
                _MaximumDate = value;
                OnPropertyChanged(nameof(MaximumDate));
            }
        }
        private int _Interval;

        public int Interval
        {
            get { return _Interval; }
            set
            {
                _Interval = value;
                OnPropertyChanged(nameof(Interval));
            }
        }
        private double _ActualMaximumCurrency;
        public double ActualMaximumCurrency
        {
            get { return _ActualMaximumCurrency; }
            set
            {
                _ActualMaximumCurrency = value;
                OnPropertyChanged(nameof(ActualMaximumCurrency));
            }
        }

        private double _ForecastMaximumCurrency;
        public double ForecastMaximumCurrency
        {
            get { return _ForecastMaximumCurrency; }
            set
            {
                _ForecastMaximumCurrency = value;
                OnPropertyChanged(nameof(ForecastMaximumCurrency));
            }
        }


        #region BindingsForPage

        private string _TotalBudget;

        public string TotalBudget
        {
            get { return _TotalBudget; }
            set
            {
                _TotalBudget = value;
                OnPropertyChanged(nameof(TotalBudget));
            }
        }

        private string _ActualCost;

        public string ActualCost
        {
            get { return _ActualCost; }
            set
            {
                _ActualCost = value;
                OnPropertyChanged(nameof(ActualCost));
            }
        }
        private float _Percentage;

        public float Percentage
        {
            get { return _Percentage; }
            set
            {
                _Percentage = value;
                OnPropertyChanged(nameof(Percentage));
            }
        }
        private string _Status;

        public string Status
        {
            get { return _Status; }
            set
            {
                _Status = value;
                OnPropertyChanged(nameof(Status));
            }
        }
        private string _StatusChangedText;

        public string StatusChangedText
        {
            get { return _StatusChangedText; }
            set
            {
                _StatusChangedText = value;
                OnPropertyChanged(nameof(StatusChangedText));
            }
        }

        private string _TimeLine;

        public string TimeLine
        {
            get { return _TimeLine; }
            set
            {
                _TimeLine = value;
                OnPropertyChanged(nameof(TimeLine));
            }
        }
        private string _BaseLineStartDate;

        public string BaseLineStartDate
        {
            get { return _BaseLineStartDate; }
            set
            {
                _BaseLineStartDate = value;
                OnPropertyChanged(nameof(BaseLineStartDate));
            }
        }
        private string _BaseLineEndDate;

        public string BaseLineEndDate
        {
            get { return _BaseLineEndDate; }
            set
            {
                _BaseLineEndDate = value;
                OnPropertyChanged(nameof(BaseLineEndDate));
            }
        }
        private string _BudgetProjectionText;

        public string BudgetProjectionText
        {
            get { return _BudgetProjectionText; }
            set
            {
                _BudgetProjectionText = value;
                OnPropertyChanged(nameof(BudgetProjectionText));
            }
        }
        private string _ProjectLeadName;

        public string ProjectLeadName
        {
            get { return _ProjectLeadName; }
            set
            {
                _ProjectLeadName = value;
                OnPropertyChanged(nameof(ProjectLeadName));
            }
        }

        private Users _ProjectLeadData;

        public Users ProjectLeadData
        {
            get { return _ProjectLeadData; }
            set
            {
                _ProjectLeadData = value;
                OnPropertyChanged(nameof(ProjectLeadData));
            }
        }

        private ProjectModel _ProjectSelected;

        public ProjectModel ProjectSelected
        {
            get { return _ProjectSelected; }
            set
            {
                _ProjectSelected = value;
                OnPropertyChanged(nameof(ProjectSelected));
            }
        }


        private string _Description;

        public string Description
        {
            get { return _Description; }
            set
            {
                _Description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        private string _OverallHealth;

        public string OverallHealth
        {
            get { return _OverallHealth; }
            set
            {
                _OverallHealth = value;
                OnPropertyChanged(nameof(OverallHealth));
            }
        }


        private ObservableCollection<Users> _UsersData;

        public ObservableCollection<Users> UsersData
        {
            get { return _UsersData; }
            set
            {
                _UsersData = value;
                OnPropertyChanged(nameof(UsersData));
            }
        }
        #endregion

        DateTime date;

        public ProjectDetailsViewModel(ProjectModel selectedproject)
        {
            ProjectTitle = selectedproject.ProjectName;
            ProjectDesc = selectedproject.ProjectShortDescription;
            Description = selectedproject.Description;
            ActualCost ="$"+ NumberExtension.FormatNumber(Convert.ToDouble(selectedproject.ActualCost));
            TotalBudget = "$" + NumberExtension.FormatNumber(Convert.ToDouble(selectedproject.TotalBudget));
            Status = selectedproject.Status;
            StatusChangedText = ((DateTime.Now.Date - selectedproject.StatusChangeDate).TotalDays) + " days since last changed";
            BaseLineStartDate = selectedproject.BaselineStartDate.ToString("MMM-yy");
            BaseLineEndDate = selectedproject.BaselineEndDate.ToString("MMM-yy");
            TimeLine = (DateExtension.MonthDifference(selectedproject.BaselineEndDate,selectedproject.BaselineStartDate))+" months";
            BudgetProjectionText = selectedproject.BudgetProjectiontext;
            ProjectSelected = selectedproject;
            Percentage = float.Parse(selectedproject.Percentage)/100f;
            RemoveUserCommand = new Command(RemovePerson);

            Is1YSelected = true;
            date = new DateTime(2022, 01, 01);
            GetProjectUserRoleMappingData(selectedproject);
            GetScoreDetailRecordFromMaster(selectedproject);
            FillHealthProjectionData(selectedproject);
        }

        public void ChangeCurrencyGraphData()
        {
            var currentdate = DateTime.ParseExact(DateTime.Now.Date.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //var startdate = DateTime.ParseExact(BaseLineStartDate, "MMM-yy", CultureInfo.InvariantCulture);

            if (Is1MSelected)
            {
                var startdate = new DateTime(currentdate.Year,currentdate.Month,1);
                var enddate = new DateTime(currentdate.Year, currentdate.AddMonths(1).Month, 1);
                var interval = 1;
                startdate = DateTime.ParseExact(startdate.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                enddate= DateTime.ParseExact(enddate.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                GetProjectSliceDetails(startdate, enddate, currentdate, interval);
                
            }
            else if (Is3MSelected)
            {
                var startdate = currentdate.AddMonths(-3);
                var enddate = currentdate.AddMonths(3);
                var interval = 2;
                startdate = DateTime.ParseExact(startdate.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                enddate = DateTime.ParseExact(enddate.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                GetProjectSliceDetails(startdate, enddate, currentdate, interval);
            }
            else if (Is6MSelected)
            {
                var startdate = currentdate.AddMonths(-6);
                var enddate = currentdate.AddMonths(6);
                var interval = 3;
                startdate = DateTime.ParseExact(startdate.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                enddate = DateTime.ParseExact(enddate.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                GetProjectSliceDetails(startdate, enddate, currentdate, interval);
            }
            else if (Is1YSelected)
            {
                var startdate = currentdate.AddYears(-1);
                var enddate = currentdate.AddYears(1);
                var interval = 6;
                startdate = DateTime.ParseExact(startdate.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                enddate = DateTime.ParseExact(enddate.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                GetProjectSliceDetails(startdate, enddate, currentdate, interval);

            }
        }

        public Command ShowProjectHealth => new Command(async () =>
        {
            //Open Popup
            //await navigation.PushAsync(new PickImagePopUP());
            await PopupNavigation.Instance.PushAsync(new ProjectHealthPage(this));
        }
       );

        public void GetProjectUserRoleMappingData(ProjectModel model)
        {
            string wherecondition = "ProjectID='" + model.ID + "'";
            var usermappingdata = DBManager.Instance().QueryTable<ProjectUserRoleMapping>("ProjectUserRoleMapping", wherecondition);
            if (usermappingdata != null && usermappingdata.Count > 0)
            {
                var projectlead = usermappingdata.Where(x => x.ProjectRoleName?.ToLower() == "project lead")?.FirstOrDefault();
                if (projectlead != null)
                {
                    string whereconditionforuser = "ID='" + projectlead.UserID + "'";
                    var leaduserdata = DBManager.Instance().QueryTable<Users>("Users", whereconditionforuser);
                    if (leaduserdata != null && leaduserdata.Count > 0)
                    {
                        ProjectLeadName = leaduserdata[0].FullName;
                        ProjectLeadData = leaduserdata[0];
                    }
                }
                UsersData = new ObservableCollection<Users>();
                foreach (var user in usermappingdata.Take(4))
                {
                    string whereconditionforuser = "ID='" + user.UserID + "'";
                    var leaduserdata = DBManager.Instance().QueryTable<Users>("Users", whereconditionforuser);
                    if (leaduserdata != null && leaduserdata.Count > 0)
                    {
                        UsersData.Add(leaduserdata[0]);
                        AddPerson(leaduserdata[0].Initials);
                    }
                    
                }
                
            }
            AddPerson("+");
        }

        public void FillHealthProjectionData(ProjectModel model)
        {
            //OverallData
            string wherecondition = "ProjectID='" + model.ID + "' and ProjectKnowledgeAreaID='1'";
            var knowledgeAreaLogDetails = DBManager.Instance().QueryTable<ProjectKnowledgeAreaLogDetails>("ProjectKnowledgeAreaLogDetails", wherecondition);
            if (knowledgeAreaLogDetails != null && knowledgeAreaLogDetails.Count > 0)
            {
                string overallhealth = "";
                HealthProjectionData = new ObservableCollection<Model>();
                HealthProjectionDataForecast = new ObservableCollection<Model>();
                //Health of project by taking actual value for current month
                foreach (var record in knowledgeAreaLogDetails)
                {
                    if (Convert.ToDateTime(record.ActualVAlueEnteredDate).Month == DateTime.Now.Month)
                    {
                        overallhealth = record.ActualValue;
                        OverallHealth = overallhealth;
                    }
                    if (!String.IsNullOrEmpty(record.ActualValue) && record.ActualValue!="0")
                    {
                        HealthProjectionData.Add(new Model()
                        {
                            XValue= Convert.ToDateTime(record.ActualVAlueEnteredDate),
                            YValue1=Convert.ToDouble(record.ActualValue)
                        });
                    }
                    else if (!String.IsNullOrEmpty(record.ForecastValue) && record.ForecastValue != "0")
                    {
                        if (HealthProjectionDataForecast != null && HealthProjectionDataForecast.Count > 0)
                        {
                            HealthProjectionDataForecast.Add(new Model()
                            {
                                XValue = Convert.ToDateTime(record.ForecastValueEnteredDate),
                                YValue1 = Convert.ToDouble(record.ForecastValue)
                            });
                        }
                        else
                        {
                            HealthProjectionDataForecast.Add(HealthProjectionData.Last());
                        }
                    }
                }
                
            }
        }

        

        public void GetScoreDetailRecordFromMaster(ProjectModel model)
        {
            ScoreDetailList = new ObservableCollection<ScoreDetailModel>();
            var projectKnowledgeAreaMaster = DBManager.Instance().GetRecords<ProjectKnowledgeAreaMaster>();
            if (projectKnowledgeAreaMaster != null && projectKnowledgeAreaMaster.Count > 0)
            {
                foreach (var singleknowledgeArea in projectKnowledgeAreaMaster.Where(x=>x.KnowledgeAreaName.ToLower()!="overall"))
                {
                    string wherecondition = "ProjectID='" + model.ID + "' and ProjectKnowledgeAreaID='"+singleknowledgeArea.ID+"'";
                    var knowledgeAreaLogDetails = DBManager.Instance().QueryTable<ProjectKnowledgeAreaLogDetails>("ProjectKnowledgeAreaLogDetails", wherecondition);
                    if (knowledgeAreaLogDetails != null && knowledgeAreaLogDetails.Count > 0)
                    {
                        var currentdatamodel = knowledgeAreaLogDetails.Where(x => Convert.ToDateTime(x.ActualVAlueEnteredDate).ToString("MMM-yy") == DateTime.Now.ToString("MMM-yy"))?.FirstOrDefault();
                        var value= currentdatamodel.ActualValue;
                        ScoreDetailList.Add(new ScoreDetailModel()
                        {
                            TitleName = singleknowledgeArea.KnowledgeAreaName,
                            Percentage = float.Parse(value) / 100f,
                            knowledgeAreaMaster= singleknowledgeArea,
                            logdetail= currentdatamodel,
                        }) ;
                    }
                    else
                    {
                        ScoreDetailList.Add(new ScoreDetailModel()
                        {
                            TitleName = singleknowledgeArea.KnowledgeAreaName,
                            Percentage = 0,
                            knowledgeAreaMaster = singleknowledgeArea,

                        });
                    }
                }
            }
           
        }

        
            public Command CloseCommand => new Command(async () =>
            {
                await PopupNavigation.Instance.PopAllAsync();
            }
        );
        public Command ScoreDetailTapped => new Command(async (scoredetailRecord) =>
        {
            
            var model = scoredetailRecord as ScoreDetailModel;
            await navigation.PushAsync(new ScoreDetailPage(model.knowledgeAreaMaster, model.logdetail, ProjectLeadData,ProjectSelected));
            await PopupNavigation.Instance.PopAllAsync();
        }
      );
        
        public Command EmailCommand => new Command(async () =>
        {
            try
            {
                if (ProjectLeadData != null) {
                    var message = new EmailMessage
                    {
                        Subject = "Magpie",
                        Body = "Type your text here",
                        To = new List<string>() { ProjectLeadData.Email },
                        //Cc = ccRecipients,
                        //Bcc = bccRecipients
                    };
                    await Email.ComposeAsync(message);
                }
            }
            catch (FeatureNotSupportedException fbsEx)
            {
                // Email is not supported on this device
            }
            catch (Exception ex)
            {
                // Some other exception occurred
            }
        }
        );

        public Command PhoneCommand => new Command(async () =>
        {
            try
            {
                if (ProjectLeadData != null)
                {
                    PhoneDialer.Open(ProjectLeadData.PhoneNumber);
                }
            }
            catch (FeatureNotSupportedException fbsEx)
            {
                // Email is not supported on this device
            }
            catch (Exception ex)
            {
                // Some other exception occurred
            }
        }
       );

        public Command ChatCommand => new Command(async () =>
        {
            try
            {
                if (ProjectLeadData != null)
                {
                    var message = new SmsMessage("Type your msg here", new[] { ProjectLeadData.PhoneNumber });
                    await Sms.ComposeAsync(message);
                }
            }
            catch (FeatureNotSupportedException fbsEx)
            {
                // Email is not supported on this device
            }
            catch (Exception ex)
            {
                // Some other exception occurred
            }
        }
      );

        public Command UserCommand => new Command(async () =>
        {
            try
            {
                
               await navigation.PushAsync(new UserManagementPage(this));
            }
            catch (Exception ex)
            {
                // Some other exception occurred
            }
        }
     );

        public Command AddUserCommand => new Command(async () =>
        {
            try
            {

                UserDialogs.Instance.Toast("Functionality under construction");
            }
            catch (Exception ex)
            {
                // Some other exception occurred
            }
        }
    );
        public Command EditUser => new Command(async () =>
        {
            try
            {

                UserDialogs.Instance.Toast("Functionality under construction");
            }
            catch (Exception ex)
            {
                // Some other exception occurred
            }
        }
    );

        private void GetProjectSliceDetails(DateTime startdate, DateTime enddate, DateTime cuttoffdate,int interval)
        {
            Data = new ObservableCollection<Model>();
            DataForecast = new ObservableCollection<Model>();
            BudgetData = new ObservableCollection<Model>();

            CurrencyData = new ObservableCollection<Model>();
            CurrencyBudgetData = new ObservableCollection<Model>();
            CurrencyForecastData = new ObservableCollection<Model>();
            string wherecondition = "ProjectID='" + ProjectSelected.ID + "'";
            List<ProjectSliceDetails> data=DBManager.Instance().QueryTable<ProjectSliceDetails>("ProjectSliceDetails", wherecondition);
            if(data!=null && data.Count > 0)
            {
               
                foreach(var record in data)
                {
                    //Percentage Data
                    DateTime slicedate = DateTime.ParseExact(record.SliceDate, "dd/MM/yyyy",
                                  CultureInfo.InvariantCulture);
                    if (slicedate >= startdate && slicedate <= enddate)
                    {
                        #region PercentageData
                        //Budget
                        Model budgetmodel = new Model()
                        {
                            XValue = slicedate,
                            YValue1 = Convert.ToDouble(record.SPI.Replace("%", ""))
                        };
                        BudgetData.Add(budgetmodel);

                        Model commonmodel = new Model()
                        {
                            XValue = slicedate,
                            YValue1 = Convert.ToDouble(record.CPI.Replace("%", ""))
                        };
                        if (slicedate <= cuttoffdate)
                        {
                            //Actual

                            Data.Add(commonmodel);
                        }
                        else
                        {
                            //Forecast
                            if (DataForecast == null || DataForecast.Count == 0)
                            {
                                if (Data != null && Data.Count > 0)
                                {
                                    //Data.Add(commonmodel);
                                    DataForecast.Add(Data.Last());
                                }
                                else
                                {
                                    DataForecast.Add(commonmodel);
                                }
                            }
                            else
                            {
                                DataForecast.Add(commonmodel);
                            }
                        }

                        #endregion PercentageData

                        //CurrencyData
                        #region CurrencyData
                        //Budget
                        Model budgetmodelCurrency = new Model()
                        {
                            XValue = slicedate,
                            YValue1 = Convert.ToDouble(record.PV)
                        };
                        CurrencyBudgetData.Add(budgetmodelCurrency);

                        Model commonmodelCurrency = new Model()
                        {
                            XValue = slicedate,
                            YValue1 = Convert.ToDouble(record.AC)
                        };
                        if (slicedate <= cuttoffdate)
                        {
                            //Actual

                            CurrencyData.Add(commonmodelCurrency);
                        }
                        else
                        {
                            //Forecast
                            if (CurrencyForecastData == null || CurrencyForecastData.Count == 0)
                            {
                                if (CurrencyData != null && CurrencyData.Count > 0)
                                {
                                    //CurrencyData.Add(commonmodelCurrency);
                                    CurrencyForecastData.Add(CurrencyData.Last());
                                }
                                else
                                {
                                    CurrencyForecastData.Add(commonmodelCurrency);
                                }
                            }
                            else
                            {
                                CurrencyForecastData.Add(commonmodelCurrency);
                            }
                        }

                        #endregion CurrencyData
                    }
                }
                MaximumDate = enddate;
                ;
                MinimumDate = startdate;
                ;
                Interval = interval;
                if (CurrencyBudgetData != null && CurrencyBudgetData.Count > 0)
                {
                    ActualMaximumCurrency = CurrencyBudgetData.Max(x => x.YValue1) + 10;
                    ForecastMaximumCurrency = ActualMaximumCurrency + 5;
                }
            }
        }


        #region InitialsCircleRegion
        public ICommand RemoveUserCommand { get; private set; }

        public ObservableCollection<Person> People { get; set; } = new ObservableCollection<Person>();
        List<string> Initials = new List<string>() { "NP", "SM", "SP", "RP" };
        List<Color> colors = new List<Color>()
        {
            Color.FromHex("#18A0FB"),
            Color.FromHex("#6E56F4"),
            Color.FromHex("#E8637B"),
            Color.FromHex("#7D89FC"),
            Color.FromHex("#B43BEF")

        };
        private void AddPerson(string initial)
        {
            if (initial != "+")
            {
                Random r = new Random();
                int indexofcolor = r.Next(0, colors.Count); //for ints

                // add a person using an Image from pravatar.cc
                People.Add(new Person
                {
                    Initials = initial,
                    RandomColor = colors[indexofcolor]
                });
            }
            else
            {
                People.Add(new Person
                {
                    Initials = initial,
                    RandomColor = Color.FromHex("#E9ECEE"),
                });
            }
            //OnPropertyChanged(nameof(PeopleCount));
        }

        private void RemovePerson()
        {
            if (People.Any())
            {
                People.Remove(People.Last());

                //OnPropertyChanged(nameof(PeopleCount));

            }
        }

        
        #endregion

    }


    public class Model
    {
        public DateTime XValue { get; set; }

        public double YValue1 { get; set; }

        public double YValue2 { get; set; }
        public double YValue3 { get; set; }
    }
    public class ScoreDetailModel:BaseModel
    {
        public string TitleName { get; set; }

        public float Percentage { get; set; }

        public ProjectKnowledgeAreaMaster knowledgeAreaMaster { get; set; }
        public ProjectKnowledgeAreaLogDetails logdetail { get; set; }

    }
}
