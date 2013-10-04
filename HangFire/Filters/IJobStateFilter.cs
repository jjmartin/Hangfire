﻿using HangFire.Filters;
using HangFire.States;
using ServiceStack.Redis;

namespace HangFire
{
    public interface IJobStateFilter : IJobFilter
    {
        JobState OnStateChanged(IRedisClient redis, JobState state);
        void OnStateApplied(IRedisTransaction transaction, JobState state);
        void OnStateUnapplied(IRedisTransaction transaction, string state);
    }
}