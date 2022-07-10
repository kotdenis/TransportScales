﻿namespace TransportScales.Dto.DtoModels
{
    public class TransportDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public int Weight { get; set; }
        public int AxisNumber { get; set; }
        public string Cargo { get; set; } = string.Empty;
    }
}
