using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using MagpieProject.Interfaces;
using MagpieProject.Models;
using MagpieProject.Models.NotificationsModule;
using MagpieProject.Models.UserSettings;
using SQLite;
using Xamarin.Forms;

namespace MagpieProject.Database
{
    public class DBManager
    {
        private static DBManager _instance = null;
        private readonly SQLiteConnection conn;
        private const string DBFileName = "MagpieDB.db3";

        public DBManager()
        {
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string completePath = System.IO.Path.Combine(folderPath, DBFileName);
            try
            {
                conn = new SQLiteConnection(completePath);
                conn.CreateTable<UserLoginDetails>();
                conn.CreateTable<NotificationModel>();
                conn.CreateTable<ProjectModel>();
                conn.CreateTable<UserProjectMapping>();


                conn.CreateTable<BusinessUnitMaster>();
                conn.CreateTable<CurrencyConverterDetails>();
                conn.CreateTable<CurrencyMaster>();
                conn.CreateTable<MilestoneStatusMaster>();
                conn.CreateTable<OrganizationMaster>();
                conn.CreateTable<OrganizationSettings>();
                conn.CreateTable<ProjectKnowledgeAreaLogDetails>();
                conn.CreateTable<ProjectKnowledgeAreaMaster>();
                conn.CreateTable<ProjectMilestoneLogDetails>();
                conn.CreateTable<ProjectRoleMaster>();
                conn.CreateTable<ProjectSliceDetails>();
                conn.CreateTable<ProjectUserRoleMapping>();
                conn.CreateTable<ProjectVendorMapping>();
                conn.CreateTable<RaidActivityMaster>();
                conn.CreateTable<RaidCodeMaster>();
                conn.CreateTable<RaidProjectActivityLog>();
                conn.CreateTable<RAIDProjectDetails>();
                conn.CreateTable<RaidStatusMaster>();
                conn.CreateTable<RaidTypeMaster>();
                conn.CreateTable<RegionMaster>();
                conn.CreateTable<RoleMaster>();
                conn.CreateTable<SettingsMaster>();
                conn.CreateTable<SkillsMaster>();
                conn.CreateTable<UserRoleMapping>();
                conn.CreateTable<Users>();

                conn.CreateTable<VendorCategoryMaster>();
                conn.CreateTable<VendorDetails>();
                conn.CreateTable<VendorDomainMaster>();
                conn.CreateTable<Vendors>();
                conn.CreateTable<VendorTypeMaster>();
                InsertAllDataFromFile();
                FillUsersdata();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exceptions:" + e.ToString());
            }
        }

        static internal DBManager Instance()
        {
            if (_instance == null)
            {
                _instance = new DBManager();
                DependencyService.Get<IIDBManager>().DbConnection(_instance);
            }

            return _instance;
        }

        //public int RegisterUser(Registration registration, Login credentials)
        //{
        //    int registerResult = conn.Insert(registration);

        //    return registerResult > 0 ? conn.Insert(credentials) : 0;
        //}

        public bool CheckForLoggedInUser()
        {
            UserLoginDetails data = conn.Table<UserLoginDetails>().FirstOrDefault();
            if (data != null)
            {
                App.UserID = data.userId;
                return true;
            }
            return false;
        }

        public UserLoginDetails getLoggedInUser()
        {
            UserLoginDetails data = conn.Table<UserLoginDetails>()?.FirstOrDefault();
            App.UserID = data.userId;
            return data;
            //Application.Current.Properties["IsLoggedInUser"] = "true";
        }

        public void deleteLoggedInUser()
        {
            try
            {
                UserLoginDetails data = conn.Table<UserLoginDetails>().FirstOrDefault();
                conn.Delete(data);
                truncatealltables();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
        public void truncatealltables()
        {
            try
            {

                conn.DeleteAll<ProjectModel>();
                conn.DeleteAll<UserProjectMapping>();
                conn.DeleteAll<NotificationModel>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
        //public string getUserName()
        //{
        //    return conn.Table<Data>().Select(x => x.userName).FirstOrDefault();
        //}
        //public string getName()
        //{
        //    string fullname = "";
        //    var data = conn.Table<Data>().FirstOrDefault();
        //    if (data != null)
        //    {
        //        fullname = data.firstName + (!String.IsNullOrEmpty(data.middleName) ? " " + data.middleName + " " : " ") + data.lastName;
        //    }

        //    return fullname;

        //}
        //public string getUserRole()
        //{
        //    return conn.Table<Data>().Select(x => x.userRole).FirstOrDefault();
        //}

        //public UserAppSettings getUserAppSettings()
        //{
        //    return conn.Table<UserAppSettings>().ToList().Count == 0 ? new UserAppSettings() : conn.Table<UserAppSettings>().ToList()[0];
        //}

        public bool UpdateUserAppSettings(UserLoginDetails userAppSettings)
        {
            bool status = true;
            try
            {
                conn.Update(userAppSettings);
            }
            catch
            {
                status = false;
            }

            return status;
        }

        public bool UpdateRecord<T1>(T1 data)
        {
            bool status = true;
            try
            {
                conn.Update(data);
            }
            catch
            {
                status = false;
            }

            return status;
        }

        //public void CallInsertData()
        //{
        //    NotificationModel notificationobj = new NotificationModel
        //    {
        //        Header = "Test Notification",
        //        Description = "Test Description"
        //    };
        //    InsertData(notificationobj);
        //}

        public bool InsertData(BaseModel selectedData)
        {
            bool status = true;
            try
            {
                conn.Insert(selectedData);
            }
            catch(Exception ex)
            {
                status = false;
            }

            return status;
        }

        public bool DropUserTables()
        {
            try
            {
                conn.DropTable<NotificationModel>();
                conn.DropTable<ProjectModel>();
                conn.DropTable<UserProjectMapping>();
                conn.DropTable<BusinessUnitMaster>();
                conn.DropTable<CurrencyConverterDetails>();
                conn.DropTable<CurrencyMaster>();
                conn.DropTable<MilestoneStatusMaster>();
                conn.DropTable<OrganizationMaster>();
                conn.DropTable<OrganizationSettings>();
                conn.DropTable<ProjectKnowledgeAreaLogDetails>();
                conn.DropTable<ProjectKnowledgeAreaMaster>();
                conn.DropTable<ProjectMilestoneLogDetails>();
                conn.DropTable<ProjectRoleMaster>();
                conn.DropTable<ProjectSliceDetails>();
                conn.DropTable<ProjectUserRoleMapping>();
                conn.DropTable<ProjectVendorMapping>();
                conn.DropTable<RaidActivityMaster>();
                conn.DropTable<RaidCodeMaster>();
                conn.DropTable<RaidProjectActivityLog>();
                conn.DropTable<RAIDProjectDetails>();
                conn.DropTable<RaidStatusMaster>();
                conn.DropTable<RaidTypeMaster>();
                conn.DropTable<RegionMaster>();
                conn.DropTable<RoleMaster>();
                conn.DropTable<SettingsMaster>();
                conn.DropTable<SkillsMaster>();
                conn.DropTable<UserRoleMapping>();
                conn.DropTable<Users>();

                conn.DropTable<VendorCategoryMaster>();
                conn.DropTable<VendorDetails>();
                conn.DropTable<VendorDomainMaster>();
                conn.DropTable<Vendors>();
                conn.DropTable<VendorTypeMaster>();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<T1> QueryTable<T1>(string tablename,string wherecondition) where T1 : new()
        {
            try
            {
                string query = "";
                if (!String.IsNullOrEmpty(wherecondition))
                {
                    query = "select * from [" + tablename + "] where " + wherecondition;
                }
                else
                {
                    query = "select * from [" + tablename + "]";
                }
                string[] param=new string[] { };
                var data = conn.Query<T1>(query, param)?.ToList();
                return data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<T1> GetRecords<T1>() where T1 : new()
        {
            var data = conn.Table<T1>().ToList();
            return data;
        }
        public int DeleteRecord<T1>(string id)
        {
            try
            {
                return conn.Delete<T1>(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return 0;
            }
        }
        public void FillNotificationsData()
        {
            var notifications = new ObservableCollection<NotificationModel>()
            {
                new NotificationModel()
                {
                    ID="1",
                    NotificationDate="DEC 28",
                    NotificationTitle="Project Name 1 Status Change",
                    NotificationDescription="Project changed to Complete status",
                    CreatedDate=DateTime.Now
                },
                 new NotificationModel()
                {
                    ID="2",
                    NotificationDate="DEC 28",
                    NotificationTitle="Project Name 2 Over Budget",
                    NotificationDescription="Project budget recently increased by 100k",
                    CreatedDate=DateTime.Now
                },
                  new NotificationModel()
                {
                    ID="3",
                    NotificationDate="DEC 28",
                    NotificationTitle="Project Name 2 High Spend",
                    NotificationDescription="Spend this month is unusually high",
                    CreatedDate=DateTime.Now
                },
            };
            foreach (var item in notifications)
            {
                InsertData(item);
            }
        }

        public void FillProjectsTable()
        {
            var AllProjectsList = new ObservableCollection<ProjectModel>()
            {
                new ProjectModel()
                {
                    ID="12",
                    ProjectName="Project Name 1",
                    ProjectShortDescription="Short description 1",
                    RangeValue="96",
                    RAGStatus="Green",
                    TotalBudget="850000",
                    ActualCost="450000",
                    Status="In Progress",
                    BudgetProjectiontext="Project is currently projecting to be completed under budget and ahead of schedule.",
                    Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.",
                    BaselineStartDate=new DateTime(2021,8,1),
                    BaselineEndDate=new DateTime(2022,07,31),
                    StatusChangeDate=new DateTime(2022,1,30),
                  
                },
                new ProjectModel()
                {
                     ID="13",
                    ProjectName="Project Name 2",
                    ProjectShortDescription="Short description 2",
                    RangeValue="50",
                    RAGStatus="Green",
                     TotalBudget="850000",
                    ActualCost="450000",
                    Status="At Risk",
                    BudgetProjectiontext="Project is currently projecting to be completed under budget and ahead of schedule.",
                    Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.",
                     BaselineStartDate=new DateTime(2021,8,1),
                     BaselineEndDate=new DateTime(2022,07,31),
                    StatusChangeDate=new DateTime(2022,1,30),
                    Percentage=((Convert.ToDouble(450000/850000))*100).ToString(),
                },
                new ProjectModel()
                {
                     ID="14",
                    ProjectName="Project Name 3",
                    ProjectShortDescription="Short description 3",
                    RangeValue="80",
                    RAGStatus="Green",
                     TotalBudget="850000",
                    ActualCost="450000",
                    Status="Not Started",
                    BudgetProjectiontext="Project is currently projecting to be completed under budget and ahead of schedule.",
                    Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.",
                    BaselineStartDate=new DateTime(2021,8,1),
                    BaselineEndDate=new DateTime(2022,07,31),
                    StatusChangeDate=new DateTime(2022,1,30),
                    Percentage=((Convert.ToDouble(450000/850000))*100).ToString(),
                },
                new ProjectModel()
                {
                     ID="15",
                    ProjectName="Project Name 4",
                    ProjectShortDescription="Short description 4",
                    RangeValue="76",
                    RAGStatus="Green",
                     TotalBudget="850000",
                    ActualCost="450000",
                    Status="In Progress",
                    BudgetProjectiontext="Project is currently projecting to be completed under budget and ahead of schedule.",
                    Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.",
                    BaselineStartDate=new DateTime(2021,8,1),
                     BaselineEndDate=new DateTime(2022,07,31),
                    StatusChangeDate=new DateTime(2022,1,30),
                    Percentage=((Convert.ToDouble(450000/850000))*100).ToString(),
                },
                new ProjectModel()
                {
                     ID="16",
                    ProjectName="Project Name 5",
                    ProjectShortDescription="Short description 5",
                    RangeValue="20",
                    RAGStatus="Green",
                     TotalBudget="850000",
                    ActualCost="450000",
                    Status="In Progress",
                    BudgetProjectiontext="Project is currently projecting to be completed under budget and ahead of schedule.",
                    Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.",
                    BaselineStartDate=new DateTime(2022,1,1),
                    BaselineEndDate=new DateTime(2022,12,31),
                    StatusChangeDate=new DateTime(2022,1,30),
                    Percentage=((Convert.ToDouble(450000/850000))*100).ToString(),
                },
                new ProjectModel()
                {
                     ID="17",
                    ProjectName="Project Name 6",
                    ProjectShortDescription="Short description 6",
                    RangeValue="10",
                    RAGStatus="Green",
                     TotalBudget="850000",
                    ActualCost="450000",
                    Status="In Progress",
                    BudgetProjectiontext="Project is currently projecting to be completed under budget and ahead of schedule.",
                    Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.",
                    BaselineStartDate=new DateTime(2022,1,1),
                    BaselineEndDate=new DateTime(2022,12,31),
                    StatusChangeDate=new DateTime(2022,1,30),
                    Percentage=((Convert.ToDouble(450000/850000))*100).ToString(),
                },
                new ProjectModel()
                {
                     ID="18",
                    ProjectName="Project Name 7",
                    ProjectShortDescription="Short description 7",
                    RangeValue="80",
                    RAGStatus="Green",
                     TotalBudget="850000",
                    ActualCost="450000",
                    Status="In Progress",
                    BudgetProjectiontext="Project is currently projecting to be completed under budget and ahead of schedule.",
                    Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.",
                    BaselineStartDate=new DateTime(2022,1,1),
                    BaselineEndDate=new DateTime(2022,12,31),
                    StatusChangeDate=new DateTime(2022,1,30),
                    Percentage=((Convert.ToDouble(450000/850000))*100).ToString(),
                },
                new ProjectModel()
                {
                     ID="19",
                    ProjectName="Project Name 8",
                    ProjectShortDescription="Short description 8",
                    RangeValue="99",
                    RAGStatus="Green",
                     TotalBudget="850000",
                    ActualCost="450000",
                    Status="In Progress",
                    BudgetProjectiontext="Project is currently projecting to be completed under budget and ahead of schedule.",
                    Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.",
                    BaselineStartDate=new DateTime(2022,1,1),
                    BaselineEndDate=new DateTime(2022,12,31),
                    StatusChangeDate=new DateTime(2022,1,30),
                    Percentage=((Convert.ToDouble(450000/850000))*100).ToString(),
                }
            };
            foreach (var item in AllProjectsList)
            {
                var percentage = Convert.ToDouble(item.ActualCost) / Convert.ToDouble(item.TotalBudget);
                percentage = percentage * 100;
                item.Percentage = percentage.ToString();
                InsertData(item);
            }
        }

        public void FillUsersdata()
        {
            var usersList = new ObservableCollection<Users>()
            {
                new Users()
                {
                    ID="1",
                    FirstName="Saurabh",
                    LastName="Mehta",
                    Email="saurabh.mehta@gmail.com",
                    PhoneNumber="9892208955",
                    FullName="Saurabh Mehta",
                    Initials="SM",
                    UserID="1",
                    Password="admin"

                },
                new Users()
                {
                    ID="2",
                    FirstName="Sarah",
                    LastName="Hunter",
                    Email="sarah.hunter@gmail.com",
                    PhoneNumber="9892208955",
                    FullName="Sarah Hunter",
                    Initials="SH",
                    UserID="2",
                    Password="admin"

                },
                new Users()
                {
                    ID="3",
                    FirstName="Kelly",
                    LastName="Brown",
                    Email="kelly.brown@gmail.com",
                    PhoneNumber="9892208955",
                    FullName="Kelly Brown",
                    Initials="KB",
                    UserID="3",
                    Password="admin"

                },
            };
            foreach (var item in usersList)
            {
                InsertData(item);
            }
        }
        public void FillProjectUserRoleMappingData()
        {
            var usersList = new ObservableCollection<ProjectUserRoleMapping>()
            {
                new ProjectUserRoleMapping()
                {
                    ID="1",
                    UserID="1",
                    ProjectID="12",
                    ProjectRoleID="1",
                    ProjectRoleName="Project Lead",
                    
                },
                new ProjectUserRoleMapping()
                {
                    ID="2",
                    UserID="2",
                    ProjectID="12",
                    ProjectRoleID="1",
                    ProjectRoleName="Developer",

                },
                new ProjectUserRoleMapping()
                {
                    ID="3",
                    UserID="3",
                    ProjectID="12",
                    ProjectRoleID="1",
                    ProjectRoleName="Developer",

                },
                new ProjectUserRoleMapping()
                {
                    ID="4",
                    UserID="4",
                    ProjectID="12",
                    ProjectRoleID="1",
                    ProjectRoleName="Developer",

                },

                new ProjectUserRoleMapping()
                {
                    ID="5",
                    UserID="1",
                    ProjectID="13",
                    ProjectRoleID="1",
                    ProjectRoleName="Project Lead",

                },
                new ProjectUserRoleMapping()
                {
                    ID="6",
                    UserID="2",
                    ProjectID="13",
                    ProjectRoleID="1",
                    ProjectRoleName="Developer",

                },
            };
            foreach (var item in usersList)
            {
                InsertData(item);
            }
        }

       
        public void FillAllDummyData()
        {
            FillProjectsTable();
            FillNotificationsData();
            FillProjectUserRoleMappingData();
        }

        public List<ProjectModel> GetUserFavProjects()
        {
            try
            {

                string query = "UserID='" + App.UserID + "'";
                string projectmodelquery = "";
                string projectids = "";
                List<UserProjectMapping> userprojectmapping = DBManager.Instance().QueryTable<UserProjectMapping>("UserProjectPreferences", query).OrderBy(x=>x.Sequence).ToList();
                if (userprojectmapping != null && userprojectmapping.Count > 0)
                {
                    foreach (var item in userprojectmapping)
                    {
                        if (String.IsNullOrEmpty(projectids))
                        {
                            projectids += "'" + item.ProjectID + "'";
                        }
                        else
                        {
                            projectids += "," + "'" + item.ProjectID + "'";
                        }
                    }
                    if (!String.IsNullOrEmpty(projectids))
                    {
                        projectmodelquery = "ID IN (" + projectids + ")";
                    }
                    var myprojectdata = DBManager.Instance().QueryTable<ProjectModel>("ProjectDetails", projectmodelquery);
                   
                    foreach(var item in userprojectmapping)
                    {
                            myprojectdata.Where(x => x.ID == item.ProjectID).FirstOrDefault().TempSequence=item.Sequence;
                        
                    }
                    return myprojectdata.OrderBy(x=>x.TempSequence).ToList();
                }
                return default(List<ProjectModel>);
            }
            catch (Exception ex)
            {
                return default(List<ProjectModel>);
            }
        }


        public void InsertAllDataFromFile()
        {
            #region How to load a text file embedded resource
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(DBManager)).Assembly;
            Stream stream = assembly.GetManifestResourceStream("MagpieProject.InsertQueries.txt");

            string query = "";
            using (var reader = new StreamReader(stream))
            {
                query = reader.ReadToEnd();
            }
            #endregion

            var statements = query.Replace("\n","").Replace("N'","'").Split(new[] { ';' },
    StringSplitOptions.RemoveEmptyEntries);
                foreach (var statement in statements)
                {
                    conn.Execute(statement);
                }
        }
    }
}
