﻿using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SeewoHelper.Forms
{
    public partial class KeywordEditWindow : UIForm, IReturnableForm<List<Keyword>, List<Keyword>>
    {
        private List<Keyword> _keywords;

        public KeywordEditWindow()
        {
            InitializeComponent();
            Program.FormStyleController.Initialize(this);
        }

        public List<Keyword> GetResult(List<Keyword> list)
        {
            _keywords = list;
            listViewKeywords.Items.AddRange(list.Select(x => new ListViewItem(x.Pattern) { Tag = x }).ToArray());
            ShowDialog();

            return _keywords;
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            _keywords = listViewKeywords.Items.Cast<ListViewItem>().Select(x => (Keyword)x.Tag).ToList();
            Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var keyword = new KeywordGettingWindow().GetResult();

            if (keyword is not null)
            {
                listViewKeywords.Items.Add(new ListViewItem(keyword.Pattern) { Tag = keyword });
            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            listViewKeywords.SelectedItems.Remove();
        }

        private void ListViewKeywords_DoubleClick(object sender, EventArgs e)
        {
            var selectedItem = listViewKeywords.SelectedItems.Cast<ListViewItem>().SingleOrDefault();

            if (selectedItem is not null)
            {
                var keyword = new KeywordGettingWindow().GetResult((Keyword)selectedItem.Tag);

                if (keyword is not null)
                {
                    var item = new ListViewItem(keyword.Pattern) { Tag = keyword };
                    listViewKeywords.Items[selectedItem.Index] = item;
                }
            }
        }

        private void KeywordEditWindow_Load(object sender, EventArgs e)
        {
            Program.Logger.Info($"开始加载 {nameof(KeywordEditWindow)}");
            Program.Logger.Info($"{nameof(KeywordEditWindow)} 加载完成");
        }
    }
}
