using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using MagpieProject.Database;
using MagpieProject.Models;
using MagpieProject.Models.UserSettings;
using MagpieProject.ViewModels.SearchModule;
using MagpieProject.Views.ProjectsModule;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;

namespace MagpieProject.ViewModels.ProjectsModule
{
    public class MyProjectsViewModel : BaseViewModel
    {
        public INavigation navigation { get; set; }
        private ObservableCollection<ProjectModel> _MyProjectList;

        public ObservableCollection<ProjectModel> MyProjectList
        {
            get { return _MyProjectList; }
            set
            {
                _MyProjectList = value;
                OnPropertyChanged(nameof(MyProjectList));
            }
        }
        private LayoutState _CurrentState;

        public LayoutState CurrentState
        {
            get { return _CurrentState; }
            set
            {
                _CurrentState = value;
                OnPropertyChanged(nameof(CurrentState));
            }
        }

        public MyProjectsViewModel()
        {
            CurrentState = LayoutState.Loading;
            ItemDragged = new Command<ProjectModel>(OnItemDragged);
            ItemDraggedOver = new Command<ProjectModel>(OnItemDraggedOver);
            ItemDragLeave = new Command<ProjectModel>(OnItemDragLeave);
            ItemDropped = new Command<ProjectModel>(i => OnItemDropped(i));
            MessagingCenter.Unsubscribe<SearchViewModel>(this, "RefreshProjects");
            MessagingCenter.Unsubscribe<MyProjectsViewModel>(this, "RefreshProjects");
            MessagingCenter.Subscribe<SearchViewModel>(this, "RefreshProjects", refreshlist);
            MessagingCenter.Subscribe<MyProjectsViewModel>(this, "RefreshProjects", refreshlist);

            refreshlist();
        }
        public void refreshlist(object x=null)
        {
            var data = DBManager.Instance().GetUserFavProjects();
            MyProjectList = new ObservableCollection<ProjectModel>();
            if (data != null && data.Count > 0)
            {
                MyProjectList = new ObservableCollection<ProjectModel>(data);
            }
            showLoader();
        }
       
        public async void showLoader()
        {
            await Task.Delay(4000);
            CurrentState = LayoutState.None;
        }
        public Command ProjectTapped => new Command(async (model) =>
        {
            var projectmodel = model as ProjectModel;
            if (projectmodel != null)
            {
                await navigation.PushAsync(new ProjectDetailPage(projectmodel));
            }
        });
        public Command RemoveFavoriteCommand => new Command(async (model) =>
        {
            ConfirmConfig alertConfig = new ConfirmConfig();
            alertConfig.OkText = "Remove";
            alertConfig.CancelText = "Cancel";
            alertConfig.Message = "If you remove, you may lose access to this project";
            alertConfig.Title = "Are you sure you want remove this project?";
            
            bool yesorno=await UserDialogs.Instance.ConfirmAsync(alertConfig);
            if (yesorno)
            {
                var selectedmodel = (ProjectModel)model;
                string wherecondition = "ProjectID='" + selectedmodel.ID + "'";
                var usermappingdata = DBManager.Instance().QueryTable<UserProjectMapping>("UserProjectPreferences", wherecondition);
                if (usermappingdata != null && usermappingdata.Count > 0)
                {
                    int result = DBManager.Instance().DeleteRecord<UserProjectMapping>(usermappingdata.FirstOrDefault().ID);
                    if (result == 1)
                    {
                        MessagingCenter.Send(this, "RefreshProjects");
                        MessagingCenter.Send(this, "RefreshSearch");
                    }
                }
            }
        });

        public Command DoneCommand => new Command(async () =>
        {
            if (MyProjectList != null && MyProjectList.Count > 0)
            {
                int notcompleted = 0;
                foreach (var myprojects in MyProjectList)
                {
                    string wherecondition = "ProjectID='" + myprojects.ID + "'";
                    var usermappingdataforitemmoved = DBManager.Instance().QueryTable<UserProjectMapping>("UserProjectPreferences", wherecondition);
                    if (usermappingdataforitemmoved != null && usermappingdataforitemmoved.Count > 0)
                    {
                        usermappingdataforitemmoved.FirstOrDefault().Sequence = MyProjectList.IndexOf(myprojects);
                        bool result = DBManager.Instance().UpdateRecord<UserProjectMapping>(usermappingdataforitemmoved.FirstOrDefault());
                        if (!result)
                        {
                            notcompleted++;
                        }
                    }
                }
                if (notcompleted == 0)
                {

                    MessagingCenter.Send(this, "RefreshProjects");
                    await navigation.PopAsync();
                    return;
                }
            }
            await navigation.PopAsync();    
            
        });


        public ICommand ItemDragged { get; }
        public ICommand ItemDraggedOver { get; }
        public ICommand ItemDragLeave { get; }
        public ICommand ItemDropped { get; }

        private void OnItemDragged(ProjectModel item)
        {
            //Debug.WriteLine($"OnItemDragged: {item?.Title}");
            MyProjectList.ToList().ForEach(i => i.IsBeingDragged = item == i);
        }

        private void OnItemDraggedOver(ProjectModel item)
        {
            //Debug.WriteLine($"OnItemDraggedOver: {item?.Title}");
            var itemBeingDragged = MyProjectList.ToList().FirstOrDefault(i => i.IsBeingDragged);
            MyProjectList.ToList().ForEach(i => i.IsBeingDraggedOver = item == i && item != itemBeingDragged);
        }

        private void OnItemDragLeave(ProjectModel item)
        {
            //Debug.WriteLine($"OnItemDragLeave: {item?.Title}");
            MyProjectList.ToList().ForEach(i => i.IsBeingDraggedOver = false);
        }

        private async Task OnItemDropped(ProjectModel item)
        {
            var itemToMove = MyProjectList.ToList().First(i => i.IsBeingDragged);
            var itemToInsertBefore = item;
            var indexofmove = MyProjectList.IndexOf(itemToMove);
            var indexofinsertbefore = MyProjectList.IndexOf(itemToInsertBefore);
            if (itemToMove == null || itemToInsertBefore == null || itemToMove == itemToInsertBefore)
                return;
            MyProjectList.Remove(itemToMove);
            MyProjectList.Insert(indexofinsertbefore, itemToMove);

            
        }
        //private async Task OnItemDropped(ItemViewModel item)
        //{
        //    //var itemToMove = items.First(i => i.IsBeingDragged);
        //    //var itemToInsertBefore = item;
        //    //if (itemToMove == null || itemToInsertBefore == null || itemToMove == itemToInsertBefore)
        //    //    return;

        //    //var categoryToMoveFrom = GroupedItems.First(g => g.Contains(itemToMove));
        //    //categoryToMoveFrom.Remove(itemToMove);

        //    //var categoryToMoveTo = GroupedItems.First(g => g.Contains(itemToInsertBefore));
        //    //var insertAtIndex = categoryToMoveTo.IndexOf(itemToInsertBefore);
        //    //itemToMove.Category = categoryToMoveFrom.Name;
        //    //categoryToMoveTo.Insert(insertAtIndex, itemToMove);
        //    //itemToMove.IsBeingDragged = false;
        //    //itemToInsertBefore.IsBeingDraggedOver = false;
        //}
    }
}
