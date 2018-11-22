﻿using System;
using System.Collections.Generic;
using System.Linq;
using com.petronas.myevents.api.Models;
using com.petronas.myevents.api.Repositories.Interfaces;
using com.petronas.myevents.api.Services.Interfaces;

namespace com.petronas.myevents.api.Services
{
    public class EventMediaService : IEventMediaService
    {
        private readonly IMediaRepository _mediaRepository;
        public EventMediaService(IMediaRepository mediaRepository)
        {
            _mediaRepository = mediaRepository;
        }

        public IEnumerable<Media> GetMedias(string eventId, string mediaType, int skip, int take)
        {
            return _mediaRepository.GetAll().Where(x => !x.IsDeleted && x.EventId == eventId && x.MediaType == mediaType).Skip(skip).Take(take).ToList();
        }
    }
}
