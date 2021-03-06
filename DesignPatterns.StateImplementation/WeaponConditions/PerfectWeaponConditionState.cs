﻿using DesignPatterns.StateImplementation.WeaponConditions.Interfaces;

namespace DesignPatterns.StateImplementation.WeaponConditions
{
    /// <summary>
    /// The Weapon Condition State for a perfect weapon that has almost no uses.
    /// </summary>
    public class PerfectWeaponConditionState :
        WeaponConditionState
    {
        /// <summary>
        /// Number of Weapon Uses for this state.
        /// </summary>
        private int _weaponUses;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public PerfectWeaponConditionState()
        {
            
        }

        /// <summary>
        /// Specific Constructor.
        /// </summary>
        /// <param name="weaponUses">Number of weapon uses to start with.</param>
        public PerfectWeaponConditionState(
            int weaponUses)
        {
            _weaponUses = weaponUses;
        }

        #region IItem

        /// <summary>
        /// The common name of an item.
        /// </summary>
        public override string Name
        {
            get { return "Perfect"; }
        }

        /// <summary>
        /// The description of an item.
        /// </summary>
        public override string Description
        {
            get { return "This weapon is in perfect condition."; }
        }

        /// <summary>
        /// The weight of an item. Some items may not weigh anything.
        /// </summary>
        public override decimal Weight
        {
            get { return 0; }
        }

        #endregion

        #region IWeaponConditionState

        /// <summary>
        /// Can the weapon be picked up.
        /// </summary>
        public override bool CanBePickedUp
        {
            get { return true; }
        }

        /// <summary>
        /// Can the weapon be used.
        /// </summary>
        public override bool CanBeUsed
        {
            get { return true; }
        }

        /// <summary>
        /// The accuracy multiplier for the weapon in this state.
        /// </summary>
        public override decimal AccuracyMulitplier
        {
            get { return 1m; }
        }

        /// <summary>
        /// The number of uses before the weapon condition state changes.
        /// </summary>
        public override int UsesBeforeConditionStateChange
        {
            get { return 200; }
        }

        /// <summary>
        /// The number of times the weapon has been used in this state.
        /// </summary>
        public override int WeaponUses
        {
            get { return _weaponUses; }
        }

        /// <summary>
        /// The method to call when the weapon gets used.
        /// </summary>
        public override void WeaponUsed()
        {
            _weaponUses++;
            if (_weaponUses < UsesBeforeConditionStateChange)
                return;

            Reset();
            var nextState = ((IWeaponCondition)StateContext).UsedWeaponCondition;
            nextState.Reset();
            StateContext.CurrentState = nextState;
        }

        /// <summary>
        /// Method to reset the state of this condition.
        /// This will set the WeaponUses variable to 0.
        /// </summary>
        public override void Reset()
        {
            _weaponUses = 0;
        }

        #endregion
    }
}
