﻿using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using TransportScales.Core.Services.Interfaces;
using TransportScales.Data.Entities;
using TransportScales.Data.Repositries.Interfaces;
using TransportScales.Dto.DtoModels;

namespace TransportScales.Core.Services.Implementation
{
    public class TransportService : ITransportService
    {
        private readonly ICacheManager _cacheManager;
        private readonly ITransportRepository _transportRepository;
        private readonly IJournalRepository _journalRepository;
        private readonly IMapper _mapper;
        private readonly ITransportQuantityRepository _quantityRepository;
        private readonly IValidator<TransportDto> _validator;

        public TransportService(ICacheManager cacheManager,
            ITransportRepository transportRepository,
            IJournalRepository journalRepository,
            ITransportQuantityRepository quantityRepository,
            IValidator<TransportDto> validator,
            IMapper mapper)
        {
            _cacheManager = cacheManager;
            _transportRepository = transportRepository;
            _journalRepository = journalRepository;
            _quantityRepository = quantityRepository;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<TransportDto> GetRandomTransportAsync(CancellationToken ct)
        {
            var key = "transport";
            var result = await _cacheManager.GetAsync(key, async () =>
            {
                var entities = await _transportRepository.GetAllAsync(ct);
                entities = entities.ToList();
                await _cacheManager.SetAsync(key, entities);
                return entities;
            }).GetAwaiter().GetResult();
            var quantities = await _quantityRepository.GetAllAsync(ct);
            var quantity = quantities.Select(x => x.Quantity).FirstOrDefault();
            var random = new Random();
            var transportId = random.Next(quantity);
            var entity = result.Where(x => x.Id == transportId).FirstOrDefault();
            var dto = _mapper.Map<TransportDto>(entity);
            return dto;
        }

        public async Task<List<JournalDto>> SaveTransportWeightAsync(JournalDto journalDto, CancellationToken ct)
        {
            var journal = _mapper.Map<Journal>(journalDto);
            journal.WeighinDate = DateTime.UtcNow;
            journal.Date = DateTime.UtcNow.ToShortDateString();
            journal.Time = DateTime.UtcNow.ToShortTimeString();
            var journals = await _journalRepository.CreateAsync(journal, ct);
            var dtos = _mapper.ProjectTo<JournalDto>(journals.AsQueryable());
            var now = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day, 0, 0, 0);
            List<JournalDto> result = new List<JournalDto>();
            try
            {
                result = dtos.Where(x => x.WeighinDate >= now).ToList();
            }
            catch (Exception ex)
            {
                result = new List<JournalDto>();
            }
            return result;
        }

        public async Task CreateNewTransportAsync(TransportDto transportDto, CancellationToken ct)
        {
            ValidationResult result = await _validator.ValidateAsync(transportDto, ct);

            if (result.IsValid)
            {
                await _cacheManager.ClearlAsync("transport");
                var quantities = await _quantityRepository.GetAllAsync(ct);
                var quantity = quantities.Select(x => x).FirstOrDefault();
                quantity.Quantity = quantity.Quantity + 1;
                var transport = _mapper.Map<Transport>(transportDto);
                await _transportRepository.CreateAsync(transport, ct);
                await _quantityRepository.UpdateAsync(quantity, ct);
            }

        }














    }
}
