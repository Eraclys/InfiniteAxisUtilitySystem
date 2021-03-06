﻿using System;
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

            var persistenceModel = intelligenceDefinition.ToPersistenceModel();

            var serialized = Serializer.Serialize(persistenceModel);

            Debug.WriteLine(serialized);

            var deserialized = Serializer.Deserialize(serialized);

            var definition = deserialized.LoadIntelligenceDefinition(intelligenceDefinition.Id);

            definition.Should().BeEquivalentTo(intelligenceDefinition);
        }

        static IntelligenceDefinition IntelligenceDefinition(params DecisionMaker[] decisionMakers) =>
            new IntelligenceDefinition(
                Guid.NewGuid(),
                Guid.NewGuid().ToString(),
                decisionMakers);

        static DecisionMaker DecisionMaker(IActionSetSelectionStrategy strategy, params ActionSet[] actionSets) =>
            new DecisionMaker(
                Guid.NewGuid(),
                Guid.NewGuid().ToString(),
                strategy,
                actionSets);

        static ActionSet ActionSet(IActionSelectionStrategy strategy, params Action[] actions) =>
            new ActionSet(
                Guid.NewGuid(),
                Guid.NewGuid().ToString(),
                strategy,
                actions);

        static Action Action(IActionScoringStrategy strategy, params Consideration[] considerations) =>
            new Action(
                Guid.NewGuid(),
                Guid.NewGuid().ToString(),
                Random.NextDouble(),
                strategy,
                considerations);

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
