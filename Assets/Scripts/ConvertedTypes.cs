﻿using System;
using System.Reflection;

public enum ComponentTypeEnum
{
    Empty,
    Timer,
    Wires,
    BigButton,
    Keypad,
    Simon,
    WhosOnFirst,
    Memory,
    Morse,
    Venn,
    WireSequence,
    Maze,
    Password,
    NeedyVentGas,
    NeedyCapacitor,
    NeedyKnob,
    Mod,
    NeedyMod
}

public static class CommonReflectedTypeInfo
{
    static CommonReflectedTypeInfo()
    {
        BombType = ReflectionHelper.FindType("Bomb");
        BombComponentsField = BombType.GetField("BombComponents", BindingFlags.Public | BindingFlags.Instance);
        NumStrikesField = BombType.GetField("NumStrikes", BindingFlags.Public | BindingFlags.Instance);
        GetTimerMethod = BombType.GetMethod("GetTimer", BindingFlags.Public | BindingFlags.Instance);

        BombComponentType = ReflectionHelper.FindType("BombComponent");
        ComponentTypeField = BombComponentType.GetField("ComponentType", BindingFlags.Public | BindingFlags.Instance);
        ModuleDisplayNameField = BombComponentType.GetMethod("GetModuleDisplayName", BindingFlags.Public | BindingFlags.Instance);
        IsSolvedField = BombComponentType.GetField("IsSolved", BindingFlags.Public | BindingFlags.Instance);

        TimerComponentType = ReflectionHelper.FindType("TimerComponent");
        TimeRemainingField = TimerComponentType.GetField("TimeRemaining", BindingFlags.Public | BindingFlags.Instance);
        GetFormattedTimeMethod = TimerComponentType.GetMethod("GetFormattedTime", BindingFlags.Public | BindingFlags.Static);
    }

    #region Bomb
    public static Type BombType
    {
        get;
        private set;
    }

    public static FieldInfo BombComponentsField
    {
        get;
        private set;
    }

    public static FieldInfo NumStrikesField
    {
        get;
        private set;
    }

    public static MethodInfo GetTimerMethod
    {
        get;
        private set;
    }
    #endregion

    #region Bomb Component
    public static Type BombComponentType
    {
        get;
        private set;
    }

    public static FieldInfo ComponentTypeField
    {
        get;
        private set;
    }

    public static MethodInfo ModuleDisplayNameField
    {
        get;
        private set;
    }

    public static FieldInfo IsSolvedField
    {
        get;
        private set;
    }
    #endregion

    #region Timer Component
    public static Type TimerComponentType
    {
        get;
        private set;
    }

    public static FieldInfo TimeRemainingField
    {
        get;
        private set;
    }

    public static MethodInfo GetFormattedTimeMethod
    {
        get;
        private set;
    }
    #endregion
}
