using CommunityToolkit.Mvvm.Input;
using TripPlanner.Models;

namespace TripPlanner.PageModels;

public interface IProjectTaskPageModel
{
	IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
	bool IsBusy { get; }
}