using Microsoft.JavaScript.NodeApi;
using Microsoft.JavaScript.NodeApi.Runtime;
using System.Reflection;

namespace LivelinkClient
{
    public partial class Form1 : Form
    {
        private dynamic _module;
        private NodeEmbeddingPlatform _platform;
        private NodeEmbeddingThreadRuntime _runtime;

        public Form1()
        {
            InitializeComponent();
            // Find the path to the libnode binary for the current platform.
            string baseDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
            string libnodePath = Path.Combine(baseDir, "runtimes", "win-x64", "native", "libnode.dll");
            var settings = new NodeEmbeddingPlatformSettings
            {
                LibNodePath = libnodePath
            };
            _platform = new NodeEmbeddingPlatform(settings);
            _runtime = _platform.CreateThreadRuntime(baseDir, new NodeEmbeddingRuntimeSettings
            {
                MainScript = "globalThis.require = require('module').createRequire(process.execPath);\n"
            });

            // Import JS module inside the Dispatch call so it's on the right thread:
            // TODO: there is something to figure out to import the module in this scope
            // and being able to reuse it from another scope later
            //_runtime.Run(() =>
            //{
            //    _module = _runtime.Import("./js/math.js");
            //});
        }

        private async void buttonAdd_Click(object sender, EventArgs e)
        {
            if (double.TryParse(leftValue.Text, out double a) && double.TryParse(rightValue.Text, out double b))
            {
                try
                {
                    double result = await _runtime.RunAsync<double>(() =>
                    {
                        try
                        {
                            var module = _runtime.Import("./js/math.js");

                            var addFunc = (JSFunction)module["add"];
                            var jsArgs = new JSValue[]
                            {
                                JSValue.CreateNumber(a),
                                JSValue.CreateNumber(b)
                            };

                            var jsResult = addFunc.Call(JSValue.Undefined, jsArgs);
                            return Task.FromResult((double)jsResult);
                        }
                        catch (Exception innerEx)
                        {
                            throw new InvalidOperationException("JavaScript error: " + innerEx.Message, innerEx);
                        }
                    });

                    labelResult.Text = $"Result: {result}";
                    System.Diagnostics.Debug.WriteLine($"Result: {result}");
                }
                catch (Exception ex)
                {
                    labelResult.Text = $"JavaScript Exception: {ex.Message}";
                    System.Diagnostics.Debug.WriteLine(ex);
                }
            }
            else
            {
                labelResult.Text = "Please enter valid integers.";
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _runtime.Dispose();
            _platform.Dispose();
            base.OnFormClosed(e);
        }

        private void buttonConnectLivelink_Click(object sender, EventArgs e)
        {
            try
            {
                _runtime.Run(() =>
                {
                    try
                    {
                        var app = _runtime.Import("./js/app/app.js");
                        var connect = (JSFunction)app["connect"];
                        connect.Call(JSValue.Undefined);
                    }
                    catch (Exception innerEx)
                    {
                        throw new InvalidOperationException("JavaScript error: " + innerEx.Message, innerEx);
                    }
                });

            }
            catch (Exception ex)
            {
                labelResult.Text = $"JavaScript Exception: {ex.Message}";
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }



        private void buttonDisconnectLivelink_Click(object sender, EventArgs e)
        {
            try
            {
                _runtime.Run(() =>
                {
                    try
                    {
                        // TODO: This crash and exit with code 1, no idea why
                        var app = _runtime.Import("./js/app/app.js");
                        var disconnect = (JSFunction)app["disconnect"];
                        disconnect.Call(JSValue.Undefined);
                    }
                    catch (Exception innerEx)
                    {
                        throw new InvalidOperationException("JavaScript error: " + innerEx.Message, innerEx);
                    }
                });

            }
            catch (Exception ex)
            {
                labelResult.Text = $"JavaScript Exception: {ex.Message}";
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        private void buttonStartAnim_Click(object sender, EventArgs e)
        {
            try
            {
                _runtime.Run(() =>
                {
                    try
                    {
                        var app = _runtime.Import("./js/app/app.js");
                        var startAnimation = (JSFunction)app["startAnimation"];
                        startAnimation.Call(JSValue.Undefined);
                    }
                    catch (Exception innerEx)
                    {
                        throw new InvalidOperationException("JavaScript error: " + innerEx.Message, innerEx);
                    }
                });

            }
            catch (Exception ex)
            {
                labelResult.Text = $"JavaScript Exception: {ex.Message}";
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        private void buttonStopAllAnims_Click(object sender, EventArgs e)
        {
            try
            {
                _runtime.Run(() =>
                {
                    try
                    {
                        var app = _runtime.Import("./js/app/app.js");
                        var stopAnimations = (JSFunction)app["stopAnimations"];
                        stopAnimations.Call(JSValue.Undefined);
                    }
                    catch (Exception innerEx)
                    {
                        throw new InvalidOperationException("JavaScript error: " + innerEx.Message, innerEx);
                    }
                });

            }
            catch (Exception ex)
            {
                labelResult.Text = $"JavaScript Exception: {ex.Message}";
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }
    }
}
