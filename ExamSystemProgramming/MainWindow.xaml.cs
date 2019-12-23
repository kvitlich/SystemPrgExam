using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace ExamSystemProgramming
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //using (var context = new ThreeZeroDbContext())
            //{

            //}
        }

        private async void ProcessButtonClick(object sender, RoutedEventArgs e)
        {
            ProcessButton.IsEnabled = false;
            mainProgressBar.IsIndeterminate = true;
            StringBuilder result = new StringBuilder(3900);

            for (int i = 0; i <= 1000; i++)
            {
                await Task.Run(() =>
                {
                    result.Append($"{i} ");
                });
            }

            string saveRes = result.ToString();

          //  SaveToBd(saveRes);
            await SaveToFile(saveRes, "infosData.json");
            mainProgressBar.IsIndeterminate = false;
            ProcessButton.IsEnabled = true;
            MessageBox.Show(saveRes);
        }

        private async void SaveToBd(string data)
        {
            using (var context = new ThreeZeroDbContext())
            {
                WorkInfo workInfo = new WorkInfo
                {
                    Text = data,
                };
                context.WorkInfos.Add(workInfo);
                await context.SaveChangesAsync();
            }
        }

        private Task SaveToFile(string data, string path)
        {
            WorkInfosJsonSaveBuild saveBuild;
            if (!File.Exists(path))
            {
                saveBuild = new WorkInfosJsonSaveBuild
                {
                    WorkInfosContainer = new WorkInfosBox()
                    {
                        WorkInfos = new List<WorkInfo>
                        {
                            new WorkInfo() {Text = data}
                        }
                    }
                };
                string jsonTemp = JsonConvert.SerializeObject(saveBuild);
                File.WriteAllText(path, jsonTemp);
            }
            else
            {
                string json = File.ReadAllText(path);
                saveBuild = JsonConvert.DeserializeObject<WorkInfosJsonSaveBuild>(json);
                saveBuild.WorkInfosContainer.WorkInfos.Add(new WorkInfo { Text = data });
                json = JsonConvert.SerializeObject(saveBuild);
                File.WriteAllText(path, json);
            }
            return Task.CompletedTask;
        }
    }
}
