namespace BookingService.Core.Models.Service
{
    public class EditServiceViewModel
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public string? Duration { get; set; }
        public string? Price { get; set; }

        
        public string? Description { get; set; }
    }
}
