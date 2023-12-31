using Grpc.Net.Client;
using GrpcService;

namespace WinFormsApp1
{
    partial class Index
    {
        private System.ComponentModel.IContainer components = new System.ComponentModel.Container();
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            AutoScaleDimensions = new SizeF(8F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(925, 553);
            Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "Index";
            Text = "Running Grpc Service";
            Load += Index_Load;
            ResumeLayout(false);
        }

        private void CreateDynamicButton()
        {
            // Create a Button object  
            Button button = new Button() 
            {
                Name = "btn_click",
                Text = "Get Data (You can see title)",
                Width = 200, 
                Location = new Point(50, 50),
                BackColor = Color.AntiqueWhite
            };
            
            //Event binding
            button.Click += new EventHandler(async (object sender, EventArgs e) => 
            {
                Text = await GetString();
            });
            Controls.Add(button);
        }

        private async Task<string> GetString() 
        {
            var httpHandler = new HttpClientHandler();
            // Return `true` to allow certificates that are untrusted/invalid  
            httpHandler.ServerCertificateCustomValidationCallback =
                HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            var channel = GrpcChannel.ForAddress(_config.ServiceUrl, new GrpcChannelOptions() { HttpHandler = httpHandler });
            var client = new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(new HelloRequest { Name = "Message Found" });
            Console.WriteLine(reply.Message);
            return reply.Message ?? "No Message Found";
        }
    }
}