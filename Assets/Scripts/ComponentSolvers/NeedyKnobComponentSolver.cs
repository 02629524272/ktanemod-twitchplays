﻿using System;
using System.Collections;
using System.Reflection;
using UnityEngine;

public class NeedyKnobComponentSolver : ComponentSolver
{
    public NeedyKnobComponentSolver(BombCommander bombCommander, MonoBehaviour bombComponent, IRCConnection ircConnection, CoroutineCanceller canceller) :
        base(bombCommander, bombComponent, ircConnection, canceller)
    {
        _pointingKnob = (MonoBehaviour)_pointingKnobField.GetValue(bombComponent);
    }

    protected override IEnumerator RespondToCommandInternal(string inputCommand)
    {
        string[] commandParts = inputCommand.Split(' ');

        if (commandParts.Length != 2)
        {
            yield break;
        }

        if (!commandParts[0].Equals("rotate", StringComparison.InvariantCultureIgnoreCase))
        {
            yield break;
        }

        int totalTurnCount = 0;
        if (!int.TryParse(commandParts[1], out totalTurnCount))
        {
            yield break;
        }

        yield return "rotate";

        for (int turnCount = 0; turnCount < totalTurnCount; ++turnCount)
        {
            DoInteractionStart(_pointingKnob);
            yield return new WaitForSeconds(0.1f);
            DoInteractionEnd(_pointingKnob);

        }
    }

    static NeedyKnobComponentSolver()
    {
        _needyKnobComponentType = ReflectionHelper.FindType("NeedyKnobComponent");
        _pointingKnobField = _needyKnobComponentType.GetField("PointingKnob", BindingFlags.Public | BindingFlags.Instance);
    }

    private static Type _needyKnobComponentType = null;
    private static FieldInfo _pointingKnobField = null;

    private MonoBehaviour _pointingKnob = null;
}
