﻿namespace Consent.Api.Model
{
    public class Policy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Decision> Decisions { get; set; } = new List<Decision>();
    }
}
