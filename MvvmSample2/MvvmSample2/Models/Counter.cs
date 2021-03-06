﻿using Prism.Mvvm;

namespace MvvmSample2.Models
{
    /// <summary>
    /// カウンター
    /// </summary>
    class Counter : BindableBase
    {
        // プロパティ
        private int number;
        public int Number
        {
            get { return number; }
            // setは外部からできないようにする
            private set { SetProperty(ref number, value); }
        }

        /// <summary>
        /// Numberをデクリメント(-1)する
        /// </summary>
        public void Decrement()
        {
            Number -= 1;
        }

        /// <summary>
        /// Numberをインクリメント(+1)する
        /// </summary>
        public void Increment()
        {
            Number += 1;
        }
    }
}
