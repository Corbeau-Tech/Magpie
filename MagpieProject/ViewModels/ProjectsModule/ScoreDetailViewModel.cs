using System;
using System.Collections.Generic;
using System.Linq;
using MagpieProject.Database;
using MagpieProject.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MagpieProject.ViewModels.ProjectsModule
{
    public class ScoreDetailViewModel : BaseViewModel
    {

        private string _KeyName;

        public string KeyName
        {
            get { return _KeyName; }
            set
            {
                _KeyName = value;
                OnPropertyChanged(nameof(KeyName));
            }
        }
        private string _ActualValue;

        public string ActualValue
        {
            get { return _ActualValue; }
            set
            {
                _ActualValue = value;
                OnPropertyChanged(nameof(ActualValue));
            }
        }
        private string _CurrentScoreTitle;

        public string CurrentScoreTitle
        {
            get { return _CurrentScoreTitle; }
            set
            {
                _CurrentScoreTitle = value;
                OnPropertyChanged(nameof(CurrentScoreTitle));
            }
        }
        private string _CurrentScoreDescription;

        public string CurrentScoreDescription
        {
            get { return _CurrentScoreDescription; }
            set
            {
                _CurrentScoreDescription = value;
                OnPropertyChanged(nameof(CurrentScoreDescription));
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

        private List<Model> _TrendData;

        public List<Model> TrendData
        {
            get { return _TrendData; }
            set
            {
                _TrendData = value;
                OnPropertyChanged(nameof(TrendData));
            }
        }

        private List<Model> _TrendDataForecast;

        public List<Model> TrendDataForecast
        {
            get { return _TrendDataForecast; }
            set
            {
                _TrendDataForecast = value;
                OnPropertyChanged(nameof(TrendDataForecast));
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
        public ScoreDetailViewModel(ProjectKnowledgeAreaMaster masterdata, ProjectKnowledgeAreaLogDetails logdetails,Users projectlead, ProjectModel currentproject)
        {
            KeyName = masterdata?.KnowledgeAreaName;
            ActualValue = logdetails?.ActualValue;
            CurrentScoreTitle = masterdata?.KnowledgeAreaName.ToUpper() + " CURRENT SCORE DETAIL";
            CurrentScoreDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam";
            ProjectLeadName = projectlead?.FullName;
            ProjectLeadData = projectlead;
            FillHealthProjectionData(currentproject,masterdata);
        }

        public void FillHealthProjectionData(ProjectModel model, ProjectKnowledgeAreaMaster masterdata)
        {
            //OverallData
            string wherecondition = "ProjectID='" + model.ID + "' and ProjectKnowledgeAreaID='"+ masterdata.ID+ "'";
            var knowledgeAreaLogDetails = DBManager.Instance().QueryTable<ProjectKnowledgeAreaLogDetails>("ProjectKnowledgeAreaLogDetails", wherecondition);
            if (knowledgeAreaLogDetails != null && knowledgeAreaLogDetails.Count > 0)
            {
                string overallhealth = "";
                TrendData = new List<Model>();
                TrendDataForecast = new List<Model>();
                //Health of project by taking actual value for current month
                foreach (var record in knowledgeAreaLogDetails)
                {
                    if (Convert.ToDateTime(record.ActualVAlueEnteredDate).Month == DateTime.Now.Month)
                    {
                        overallhealth = record.ActualValue;
                        OverallHealth = overallhealth;
                    }
                    if (!String.IsNullOrEmpty(record.ActualValue) && record.ActualValue != "0")
                    {
                        TrendData.Add(new Model()
                        {
                            XValue = Convert.ToDateTime(record.ActualVAlueEnteredDate),
                            YValue1 = Convert.ToDouble(record.ActualValue)
                        });
                    }
                    else if (!String.IsNullOrEmpty(record.ForecastValue) && record.ForecastValue != "0")
                    {
                        if (TrendDataForecast != null && TrendDataForecast.Count > 0)
                        {
                            TrendDataForecast.Add(new Model()
                            {
                                XValue = Convert.ToDateTime(record.ForecastValueEnteredDate),
                                YValue1 = Convert.ToDouble(record.ForecastValue)
                            });
                        }
                        else
                        {
                            TrendDataForecast.Add(TrendData.Last());
                        }
                    }
                }

            }
        }

        public Command EmailCommand => new Command(async () =>
        {
            try
            {
                if (ProjectLeadData != null)
                {
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
    }
}
