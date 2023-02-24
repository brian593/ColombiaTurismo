﻿using System;

namespace Colombia.Models
{
    public class President
    {
        public int Id { get; set; }
        public string? Image { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public DateTime StartPeriodDate { get; set; }
        public Nullable<DateTime> EndPeriodDate { get; set; }
        public string? PoliticalParty { get; set; }
        public string? Description { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }
    }
}
