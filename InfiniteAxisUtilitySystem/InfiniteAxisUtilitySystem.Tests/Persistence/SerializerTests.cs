using System;
using System.Diagnostics;
using FluentAssertions;
using InfiniteAxisUtilitySystem.ActionScoringStrategies;
using InfiniteAxisUtilitySystem.ActionSetSelectionStrategies;
using InfiniteAxisUtilitySystem.Persistence;
using InfiniteAxisUtilitySystem.ResponseCurves;
using Xunit;

namespace InfiniteAxisUtilitySystem.Tests.Persistence
{
    public sealed class SerializerTests
    {
        [Fact]
        public void ShouldBeAbleToSerializeAndDeserialize()
        {
            var intelligenceDefinition =
                IntelligenceDefinition(
                    DecisionMaker(
                        new HighestScoringAction()),
                    DecisionMaker(
                        new RandomSelectionWeightedByScore(),
                        ActionSet(
                            new ActionSelectionStrategies.HighestScoringAction()),
                        ActionSet(
                            new ActionSelectionStrategies.RandomSelectionWeightedByScore(),
                            Action(
                                new MultiplyConsiderationScores(),
                                Consideration(LinearResponseCurve()),
                                Consideration(LogisticResponseCurve()),
                                Consideration(LogitResponseCurve()),
                                Consideration(NormalResponseCurve()),
                                Consideration(PolynomialResponseCurve()),
                                Consideration(SineResponseCurve())))));

            var serialized = Serializer.Serialize(intelligenceDefinition);

            Debug.WriteLine(serialized);

            var deserialized = Serializer.Deserialize(serialized);

            deserialized.Should().BeEquivalentTo(intelligenceDefinition);
        }

        static IntelligenceDefinition IntelligenceDefinition(params DecisionMaker[] decisionMakers)
        {
            var intelligenceDefinition = new IntelligenceDefinition(
                Guid.NewGuid(),
                Guid.NewGuid().ToString());

            foreach (var decisionMaker in decisionMakers)
            {
                intelligenceDefinition.AddDecisionMaker(decisionMaker);
            }

            return intelligenceDefinition;
        }

        static DecisionMaker DecisionMaker(IActionSetSelectionStrategy strategy, params ActionSet[] actionSets)
        {
            var decisionMaker = new DecisionMaker(
                Guid.NewGuid(),
                Guid.NewGuid().ToString(),
                strategy);

            foreach (var actionSet in actionSets)
            {
                decisionMaker.AddActionSet(actionSet);
            }

            return decisionMaker;
        }

        static ActionSet ActionSet(IActionSelectionStrategy strategy, params Action[] actions)
        {
            var actionSet = new ActionSet(
                Guid.NewGuid(),
                Guid.NewGuid().ToString(),
                strategy);

            foreach (var action in actions)
            {
                actionSet.AddAction(action);
            }

            return actionSet;
        }

        static Action Action(IActionScoringStrategy strategy, params Consideration[] considerations)
        {
            var action = new Action(
                Guid.NewGuid(),
                Guid.NewGuid().ToString(),
                Random.NextDouble(),
                strategy);

            foreach (var consideration in considerations)
            {
                action.AddConsideration(consideration);
            }

            return action;
        }

        static Consideration Consideration(IResponseCurve responseCurve) =>
            new Consideration(
                Guid.NewGuid(),
                Guid.NewGuid().ToString(),
                new Input(Guid.NewGuid(), Guid.NewGuid().ToString()),
                responseCurve);

        static LinearResponseCurve LinearResponseCurve() =>
            new LinearResponseCurve(
                Random.NextDouble(),
                Random.NextDouble(),
                Random.NextDouble());

        static LogisticResponseCurve LogisticResponseCurve() =>
            new LogisticResponseCurve(
                Random.NextDouble(),
                Random.NextDouble(),
                Random.NextDouble(),
                Random.NextDouble());

        static LogitResponseCurve LogitResponseCurve() =>
            new LogitResponseCurve(
                Random.NextDouble(),
                Random.NextDouble(),
                Random.NextDouble());

        static NormalResponseCurve NormalResponseCurve() =>
            new NormalResponseCurve(
                Random.NextDouble(),
                Random.NextDouble(),
                Random.NextDouble(),
                Random.NextDouble());

        static PolynomialResponseCurve PolynomialResponseCurve() =>
            new PolynomialResponseCurve(
                Random.NextDouble(),
                Random.NextDouble(),
                Random.NextDouble(),
                Random.NextDouble());

        static SineResponseCurve SineResponseCurve() =>
            new SineResponseCurve(
                Random.NextDouble(),
                Random.NextDouble(),
                Random.NextDouble());

        static readonly Random Random = new Random();
    }
}
