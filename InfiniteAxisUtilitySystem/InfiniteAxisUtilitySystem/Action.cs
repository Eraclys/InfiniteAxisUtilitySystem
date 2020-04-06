using System.Collections.Generic;
using System.Linq;

namespace InfiniteAxisUtilitySystem
{
    public class Action
    {
        readonly IList<Consideration> _considerations;

        public Action(
            string id,
            double weight)
        {
            Id = id;
            Weight = weight;
            _considerations = new List<Consideration>();
        }

        public string Id { get; }
        public double Weight { get; }

        public IEnumerable<Consideration> Considerations => _considerations;

        public void AddConsideration(Consideration consideration)
        {
            if (_considerations.Any(c => c.Id == consideration.Id))
            {
                return;
            }

            _considerations.Add(consideration);
        }

        public void RemoveConsideration(string id)
        {
            var toRemove = _considerations.FirstOrDefault(c => c.Id == id);

            if (toRemove != null)
            {
                _considerations.Remove(toRemove);
            }
        }

        public double Score()
        {
            var modificationFactor = 1.0 - 1.0 / _considerations.Count;
            var result = Weight;

            foreach (var consideration in _considerations)
            {
                var score = consideration.Score();
                var makeUpValue = (1.0 - score) * modificationFactor;
                score += makeUpValue * score;
                result *= score;
            }

            return result;
        }
    }
}