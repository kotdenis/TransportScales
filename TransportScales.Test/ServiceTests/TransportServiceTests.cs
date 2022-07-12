using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportScales.Core.Services.Interfaces;
using TransportScales.Dto.DtoModels;
using Xunit;

namespace TransportScales.Test.ServiceTests
{
    public class TransportServiceTests : BaseDbTest
    {
        private readonly ITransportService _transportService;

        public TransportServiceTests()
        {
            _transportService = ServiceProvider.GetRequiredService<ITransportService>();
        }

        [Fact]
        public async Task TestTransportIsRandom_Correct()
        {
            List<TransportDto> transports = new List<TransportDto>();
            bool isRandom = false;
            for (int i = 0; i < 10; i++)
            {
                var temp = await _transportService.GetRandomTransportAsync(default);
                transports.Add(temp);
                if (i > 1)
                {
                    if (temp.Number != transports[i - 1].Number)
                    {
                        isRandom = true;
                        break;
                    }
                }
            }

            Assert.True(isRandom);

        }

        [Fact]
        public async Task TestSaveTransportWeight_ModelValid()
        {
            var journalDto = new JournalDto
            {
                Cargo = "cargo",
                Name = "Kamaz",
                Date = "01.01.2001",
                Number = "A000AA",
                Time = "00:00",
                WeighinDate = DateTime.Now,
                Weight = 5000
            };
            var list = await _transportService.SaveTransportWeightAsync(journalDto, default);

            Assert.NotEmpty(list);
            Assert.True(list.Any(x => x.Number == "A000AA"));
        }

        [Fact]
        public async Task TestSaveTransportWeight_ModeInlValid()
        {
            var journalDto = new JournalDto();
            await Assert.ThrowsAsync<ValidationException>(() => _transportService.SaveTransportWeightAsync(journalDto, default));
        }
    }
}
