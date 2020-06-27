import { app, BrowserWindow, screen } from 'electron';
import * as path from 'path';

let mainWindow: BrowserWindow = null;
const serve = process.argv.slice(1).some(value => value === '--serve');

function createWindow(): BrowserWindow {
  const size = screen.getPrimaryDisplay().workAreaSize;
  mainWindow = new BrowserWindow({
    x: 0,
    y: 0,
    height: size.height,
    width: size.width,
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

  // Open the DevTools.
  // mainWindow.webContents.openDevTools();

  return mainWindow;
}

app.on('ready', () => {
  createWindow();

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
