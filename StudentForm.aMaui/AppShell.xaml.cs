using StudentForm.aMaui.View;

namespace StudentForm.aMaui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(StudentDetailPage), typeof(StudentDetailPage));
            Routing.RegisterRoute(nameof(AddEditPage), typeof(AddEditPage));
        }
    }
}