﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;  //enumerator
using System.Xml.Serialization;
using System.Runtime.Serialization;
using Models.Core;

namespace Models.WholeFarm
{

    ///<summary>
    /// Store for all the biomass growing in the fields (pasture, crop residue etc)
	/// This acts like an AnimalFoodStore but in reality the food is in a field
    ///</summary> 
    [Serializable]
    [ViewName("UserInterface.Views.GridView")]
    [PresenterName("UserInterface.Presenters.PropertyPresenter")]
    [ValidParent(ParentType = typeof(Resources))]
    public class GrazeFoodStore: Model
    {

        /// <summary>
        /// Current state of this resource.
        /// </summary>
        [XmlIgnore]
        public List<GrazeFoodStoreType> Items;

		/// <summary>An event handler to allow us to initialise ourselves.</summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		[EventSubscribe("Commencing")]
        private void OnSimulationCommencing(object sender, EventArgs e)
        {
            Items = new List<GrazeFoodStoreType>();

            List<IModel> childNodes = Apsim.Children(this, typeof(IModel));

            foreach (IModel childModel in childNodes)
            {
                //cast the generic IModel to a specfic model.
                GrazeFoodStoreType grazefood = childModel as GrazeFoodStoreType;
                Items.Add(grazefood);
            }
        }
    }


}
