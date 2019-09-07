﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GardAppUsingMVP.src.models;
using GardAppUsingMVP.src.views.interfaces;
using GardAppUsingMVP.src.logic.services;
using System.Data.SqlClient;

namespace GardAppUsingMVP.src.logic.presenters
{
   public class ItemPresenter
    {
        ItemModel itemModel = new ItemModel();
        ItemInterface itemInterface;

       public ItemPresenter(ItemInterface view)
        {
            itemInterface = view;
        }

        public void ConnectBetweenModelAndView()
        {
            itemModel.ID = itemInterface.ID;
            itemModel.ItemName = itemInterface.ItemName;
            itemModel.ItemQTY = itemInterface.ItemQty;
        }

        public bool addItem()
        {
            ConnectBetweenModelAndView();
            return ItemService.addItemService(itemModel.ID, itemModel.ItemName, itemModel.ItemQTY);
        }

        public bool deleteAllItems()
        {
            return ItemService.deleteAllItemsService();
        }



    }
}
