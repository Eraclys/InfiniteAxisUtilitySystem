using System;

namespace InfiniteAxisUtilitySystem.Persistence
{
    public class ConsiderationRecord
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IResponseCurve ResponseCurve { get; set; }
        public Guid InputId { get; set; }
    }
}
