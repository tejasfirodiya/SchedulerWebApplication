using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SchedulerWebApplication.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    public List<object> MenuItems;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public async Task OnGetAsync()
    {
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
}

public class AppointmentData
{
    public int Id { get; set; }
    public string Subject { get; set; } = null!;
    public string? Location { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string? Description { get; set; }
    public string? ContactNumber { get; set; }
}
