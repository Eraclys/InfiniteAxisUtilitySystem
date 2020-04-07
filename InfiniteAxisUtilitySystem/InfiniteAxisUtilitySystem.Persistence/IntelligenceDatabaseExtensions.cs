using System;
using System.Collections.Generic;
using System.Linq;
using InfiniteAxisUtilitySystem.Exceptions;

namespace InfiniteAxisUtilitySystem.Persistence
{
    public static class IntelligenceDatabaseExtensions
    {
        public static IntelligenceDefinition LoadIntelligenceDefinition(this IntelligenceDatabase database, Guid id)
        {
            var record = database.IntelligenceDefinitions.FirstOrDefault(x => x.Id == id)
                         ?? throw new ItemNotFoundException<IntelligenceDefinition>(id);

            return new IntelligenceDefinition(
                record.Id,
                record.Name,
                database.LoadDecisionMakers(record.DecisionMakerIds));
        }

        static IReadOnlyCollection<DecisionMaker> LoadDecisionMakers(this IntelligenceDatabase database, IEnumerable<Guid> ids)
        {
            return ids
                .DefaultToEmptyIfNull()
                .Select(database.LoadDecisionMaker)
                .Where(item => item != null)
                .ToList();
        }

        static DecisionMaker LoadDecisionMaker(this IntelligenceDatabase database, Guid id)
        {
            var record = database.DecisionMakers.FirstOrDefault(x => x.Id == id)
                         ?? throw new ItemNotFoundException<DecisionMaker>(id);

            return new DecisionMaker(
                record.Id,
                record.Name,
                record.SelectionStrategy,
                database.LoadActionSets(record.ActionSetIds));
        }

        static IReadOnlyCollection<ActionSet> LoadActionSets(this IntelligenceDatabase database, IEnumerable<Guid> ids)
        {
            return ids
                .DefaultToEmptyIfNull()
                .Select(database.LoadActionSet)
                .Where(item => item != null)
                .ToList();
        }

        static ActionSet LoadActionSet(this IntelligenceDatabase database, Guid id)
        {
            var record = database.ActionSets.FirstOrDefault(x => x.Id == id)
                         ?? throw new ItemNotFoundException<ActionSet>(id);

            return new ActionSet(
                record.Id,
                record.Name,
                record.SelectionStrategy,
                database.LoadActions(record.ActionIds));
        }

        static IReadOnlyCollection<Action> LoadActions(this IntelligenceDatabase database, IEnumerable<Guid> ids)
        {
            return ids
                .DefaultToEmptyIfNull()
                .Select(database.LoadAction)
                .Where(item => item != null)
                .ToList();
        }

        static Action LoadAction(this IntelligenceDatabase database, Guid id)
        {
            var record = database.Actions.FirstOrDefault(x => x.Id == id)
                         ?? throw new ItemNotFoundException<Action>(id);

            return new Action(
                record.Id,
                record.Name,
                record.Weight,
                record.ScoringStrategy,
                database.LoadConsiderations(record.ConsiderationIds));
        }

        static IReadOnlyCollection<Consideration> LoadConsiderations(this IntelligenceDatabase database, IEnumerable<Guid> ids)
        {
            return ids
                .DefaultToEmptyIfNull()
                .Select(database.LoadConsideration)
                .Where(item => item != null)
                .ToList();
        }

        static Consideration LoadConsideration(this IntelligenceDatabase database, Guid id)
        {
            var record = database.Considerations.FirstOrDefault(x => x.Id == id)
                         ?? throw new ItemNotFoundException<Consideration>(id);

            return new Consideration(
                record.Id,
                record.Name,
                database.LoadInput(record.InputId),
                record.ResponseCurve);
        }

        static Input LoadInput(this IntelligenceDatabase database, Guid id)
        {
            var record = database.Inputs.FirstOrDefault(x => x.Id == id)
                         ?? throw new ItemNotFoundException<Input>(id);

            return new Input(
                record.Id,
                record.Name);
        }

        public static IntelligenceDatabase ToPersistenceModel(this IntelligenceDefinition intelligenceDefinition)
        {
            var intelligenceRecord = new IntelligenceDefinitionRecord
            {
                Id = intelligenceDefinition.Id,
                Name = intelligenceDefinition.Name,
                DecisionMakerIds = intelligenceDefinition.DecisionMakers
                    .Select(x => x.Id)
                    .ToHashSet()
            };

            var decisionMakers = intelligenceDefinition.DecisionMakers
                .Select(x => new DecisionMakerRecord
                {
                    Id = x.Id,
                    Name = x.Name,
                    SelectionStrategy = x.ActionSetSelectionStrategy,
                    ActionSetIds = x.ActionSets.Select(a => a.Id).ToHashSet()
                })
                .ToList();

            var actionSets = intelligenceDefinition.DecisionMakers
                .SelectMany(x => x.ActionSets)
                .Select(x => new ActionSetRecord
                {
                    Id = x.Id,
                    Name = x.Name,
                    SelectionStrategy = x.ActionSelectionStrategy,
                    ActionIds = x.Actions.Select(a => a.Id).ToHashSet()
                })
                .ToList();

            var actions = intelligenceDefinition.DecisionMakers
                .SelectMany(x => x.ActionSets)
                .SelectMany(x => x.Actions)
                .Select(x => new ActionRecord
                {
                    Id = x.Id,
                    Name = x.Name,
                    Weight = x.Weight,
                    ScoringStrategy = x.ActionScoringStrategy,
                    ConsiderationIds = x.Considerations.Select(c => c.Id).ToHashSet()
                })
                .ToList();

            var considerations = intelligenceDefinition.DecisionMakers
                .SelectMany(x => x.ActionSets)
                .SelectMany(x => x.Actions)
                .SelectMany(x => x.Considerations)
                .Select(x => new ConsiderationRecord
                {
                    Id = x.Id,
                    Name = x.Name,
                    ResponseCurve = x.ResponseCurve,
                    InputId = x.Input.Id
                })
                .ToList();

            var inputs = intelligenceDefinition.DecisionMakers
                .SelectMany(x => x.ActionSets)
                .SelectMany(x => x.Actions)
                .SelectMany(x => x.Considerations)
                .Select(x => new InputRecord
                {
                    Id = x.Input.Id,
                    Name = x.Input.Name
                })
                .ToList();

            return new IntelligenceDatabase
            {
                IntelligenceDefinitions = new []{ intelligenceRecord },
                DecisionMakers = decisionMakers,
                ActionSets = actionSets,
                Actions = actions,
                Considerations = considerations,
                Inputs = inputs
            };
        }
    }
}