

#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    MyStateItem.cs
 * CreatedOn:   2008-05-30
 * CreatedBy:   sanshi.ustc@gmail.com
 * 
 * 
 * Description：
 *      ->
 *   
 * History：
 *      ->
 * 
 * 
 * 
 * 
 */

#endregion

using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.ComponentModel;



namespace ExtAspNet
{
    internal abstract class MyStateItem : IStateManager, ISetDirty
    {

        #region Fields

        private bool _trackingViewState = false;
        private StateBag _viewState;

        #endregion

        #region Properties

        protected StateBag ViewState
        {
            get
            {
                if (_viewState == null)
                {
                    _viewState = new StateBag(false);

                    if (_trackingViewState)
                    {
                        ((IStateManager)_viewState).TrackViewState();
                    }
                }

                return _viewState;
            }
        }

        #endregion

        #region Methods

        [Browsable(false)]
        public bool IsTrackingViewState
        {
            get
            {
                return _trackingViewState;
            }
        }

        public virtual void LoadViewState(object state)
        {
            if (state != null)
            {
                ((IStateManager)ViewState).LoadViewState(state);
            }
        }

        public virtual object SaveViewState()
        {
            if (_viewState == null)
            {
                return null;
            }
            else
            {
                return ((IStateManager)_viewState).SaveViewState();
            }
        }

        public virtual void TrackViewState()
        {
            _trackingViewState = true;

            if (_viewState != null)
            {
                ((IStateManager)_viewState).TrackViewState();
            }
        }

        #endregion

        #region old code

        //#region IStateManager Members

        //bool IStateManager.IsTrackingViewState
        //{
        //    get
        //    {
        //        return IsTrackingViewState;
        //    }
        //}

        //void IStateManager.LoadViewState(object state)
        //{
        //    LoadViewState(state);
        //}

        //object IStateManager.SaveViewState()
        //{
        //    return SaveViewState();
        //}

        //void IStateManager.TrackViewState()
        //{
        //    TrackViewState();
        //}

        //#endregion 

        #endregion

        #region ISetDirty Members

        public void SetDirty()
        {
            // 保存直接必须先设置为脏数据，否则SaveViewState返回空
            ViewState.SetDirty(true);
        }

        #endregion
    }
}