using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SchedulerWebApplication.Pages;

public class IndexModel : PageModel
{
    //private readonly IManageCalendarService _manageCalendarService;
    //public ManageCalendarDropDownsViewModel ManageCalendarDropDownsViewModel { get; set; } = null!;
    private readonly ILogger<IndexModel> _logger;
    //[BindProperty] public PersonalCalendarViewModel PersonalCalendarViewModel { get; set; } = null!;
    //public List<PersonalCalendarViewModel> DataSource { get; set; }
    public List<object> MenuItems;

    // ReSharper disable once ConvertToPrimaryConstructor
    public IndexModel(
        //IManageCalendarService manageCalendarService,
         ILogger<IndexModel> logger
        )
    {
        //_manageCalendarService = manageCalendarService;
        _logger = logger;
    }

    public async Task OnGetAsync()
    {
        await LoadDropDown();
        //PersonalCalendarViewModel = new PersonalCalendarViewModel();

        //to get appointment list
        //DataSource = await _manageCalendarService.GetAppointmentListAsync((int)CalendarTypeEnum.PersonalCalendar, (int?)VisibilityTypeEnum.Private, null);

        //implemented for right click on scheduler
        ShowContextMenu();
    }

    private void ShowContextMenu()
    {
        MenuItems =
        [
            new
            {
                text = "New Appointment",
                iconCss = "e-icons new",
                id = "Add"
            },
            new
            {
                text = "New Recurring Appointment",
                iconCss = "e-icons recurrence",
                id = "AddRecurrence"
            },
            new
            {
                text = "Go to today",
                iconCss = "e-icons today",
                id = "Today"
            },
            new
            {
                text = "Edit",
                iconCss = "e-icons edit",
                id = "Save"
            },
            new
            {
                text = "Edit Event",
                id = "EditRecurrenceEvent",
                iconCss = "e-icons edit",
                items = new List<object>
                {
                new { text = "Edit Occurrence", id = "EditOccurrence"},
                new { text = "Edit Series", id = "EditSeries" }
            }
            },
            new
            {
                text = "Delete",
                iconCss = "e-icons delete",
                id = "Delete"
            },
            new
            {
                text = "Delete Event",
                id = "DeleteRecurrenceEvent",
                iconCss = "e-icons delete",
                items = new List<object>
                {
                new { text = "Delete Occurrence", id = "DeleteOccurrence" },
                new { text = "Delete Series", id = "DeleteSeries"}
            }
            }
        ];
    }

    private async Task LoadDropDown()
    {
        //ManageCalendarDropDownsViewModel = await _manageCalendarService.GetManageCalendarDropDownsAsync(false);
    }

    //public async Task<IActionResult> OnPostSaveAsync([FromBody] EventData PersonalCalendarViewModel)
    //{
    //    try
    //    {
    //        await LoadDropDown();

    //        //var app = PersonalCalendarViewModel.PersonalCalendarViewModelEventToAdd;

    //        //app.CalendarTypeId = (int)CalendarTypeEnum.PersonalCalendar;
    //        //await _manageCalendarService.InsertAppointmentAsync(app);

    //        return await GetDataAsync();
    //    }
    //    catch (Exception ex)
    //    {
    //        _logger.LogError(ex, "Error in inserting appointment");
    //        throw;
    //    }
    //}

    //public async Task<IActionResult> OnPostUpdate([FromBody] EventData personalCalendarViewModel)
    //{
    //    try
    //    {
    //        await LoadDropDown();

    //        //var app = personalCalendarViewModel.PersonalCalendarViewModelEventToAdd;
    //        //await _manageCalendarService.UpdateAppointmentAsync(app);
    //        //_clientNotificationService.AddNotification("Appointment Updated Successfully.", NotificationType.Success);
    //        return await GetDataAsync();
    //    }
    //    catch (Exception ex)
    //    {
    //        _logger.LogError(ex, "Error in Updating Appointment");
    //        throw;
    //    }
    //}

    //public async Task<IActionResult> OnPostDeleteAsync([FromBody] EventData personalCalendarViewModel)
    //{
    //    try
    //    {
    //        await LoadDropDown();

    //        //var app = personalCalendarViewModel.PersonalCalendarViewModelEventToAdd;
    //        //await _manageCalendarService.DeleteAppointmentAsync(app.AppointmentUkId);

    //        return await GetDataAsync();
    //    }
    //    catch (Exception ex)
    //    {
    //        _logger.LogError(ex, "Error in deleting appointment");
    //        throw;
    //    }
    //}

    public async Task<IActionResult> GetDataAsync()  // Here we return data to Schedule
    {
        //var data = await _manageCalendarService.GetAppointmentListAsync((int)CalendarTypeEnum.PersonalCalendar, (int?)VisibilityTypeEnum.Private, null);
        //return new JsonResult(data);
        return null;
    }

    public class EventData
    {
        //public PersonalCalendarViewModel PersonalCalendarViewModelEventToAdd { get; set; }
    }
}

public class AppointmentData
{
    public int Id { get; set; }
    public string Subject { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}
