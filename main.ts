import { app, BrowserWindow } from 'electron';
import * as path from 'path';

let mainWindow: BrowserWindow = null;
const serve = process.argv.slice(1).some(value => value === '--serve');

function createWindow(): BrowserWindow {
  mainWindow = new BrowserWindow({
    show: false,
    webPreferences: {
      nodeIntegration: true,
      allowRunningInsecureContent: serve
    }
  });

  if (serve) {
    mainWindow.loadURL('http://localhost:4200');
  } else {
    mainWindow.loadFile(path.join(__dirname, 'dist/index.html'));
  }

  mainWindow.maximize();
  mainWindow.show();

  // Open the DevTools.
  // mainWindow.webContents.openDevTools();

  return mainWindow;
}

app.on('ready', () => {
  setTimeout(() => createWindow(), 400);

  app.on('activate', () => {
    if (BrowserWindow.getAllWindows().length === 0) createWindow();
  });
});

// Quit when all windows are closed, except on macOS. There, it's common
// for applications and their menu bar to stay active until the user quits
// explicitly with Cmd + Q.
app.on('window-all-closed', () => {
  if (process.platform !== 'darwin') {
    app.quit();
  }
});
