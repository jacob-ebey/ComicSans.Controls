using System;
using Xamarin.Forms;

namespace ComicSans.Controls
{
    /// <summary>
    /// A ListView that is capable of having submenus.
    /// </summary>
    public class SubmenuListView : ListView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComicSans.Controls.SubmenuListView"/> class.
        /// </summary>
        public SubmenuListView()
        {
            ItemSelected += OnItemSelected;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ComicSans.Controls.SubmenuListView"/> leaves the item selected when it is pressed.
        /// </summary>
        /// <value>Leaves items selected if <c>true</c>; otherwise unselects the item.</value>
        public bool LeaveSelected
        {
            get { return (bool)GetValue(LeaveSelectedProperty); }
            set { SetValue(LeaveSelectedProperty, value); }
        }

        /// <summary>
        /// Gets or sets the page generator.
        /// </summary>
        /// <value>The page generator.</value>
        public IPageGenerator PageGenerator
        {
            get { return (IPageGenerator)GetValue(PageGeneratorProperty); }
            set { SetValue(PageGeneratorProperty, value); }
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (PageGenerator?.ShouldGenerateFrom(e.SelectedItem) == true)
            {
                Page newPage = PageGenerator.Generate(e.SelectedItem);

                if (PageGenerator.ShouldSetBindingContextOfNewPage(e.SelectedItem))
                    newPage.BindingContext = e.SelectedItem;

                Navigation.PushAsync(newPage);
            }

            if (!LeaveSelected)
                (sender as ListView).SelectedItem = null;
        }

        /// <summary>
        /// Gets the leave selected property.
        /// </summary>
        /// <value>The leave selected property.</value>
        public static BindableProperty LeaveSelectedProperty { get; } =
            BindableProperty.Create<SubmenuListView, bool>(ctrl => ctrl.LeaveSelected,
                defaultValue: false,
                defaultBindingMode: BindingMode.TwoWay,
                propertyChanging: (bindable, oldValue, newValue) => ((SubmenuListView)bindable).LeaveSelected = newValue);

        /// <summary>
        /// Gets the page generator property.
        /// </summary>
        /// <value>The page generator property.</value>
        public static BindableProperty PageGeneratorProperty { get; } =
            BindableProperty.Create<SubmenuListView, IPageGenerator>(ctrl => ctrl.PageGenerator,
                defaultValue: null,
                defaultBindingMode: BindingMode.TwoWay,
                propertyChanging: (bindable, oldValue, newValue) => ((SubmenuListView)bindable).PageGenerator = newValue);
    }
}

