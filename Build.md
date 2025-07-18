# Инструкция по сборке

## Сборка через Unity Editor
1. Откройте `File → Build Settings`
2. Выберите платформу (Web)
3. Нажмите `Build`

## Командная строка (CI/CD)
```bash
# Windows
"C:\Program Files\Unity\Hub\Editor\202X.X.XfX\Editor\Unity.exe" \
  -batchmode \
  -quit \
  -projectPath "C:\path\to\MyUnityApp\Project" \
  -executeMethod BuildScript.BuildWebGL \
  -logFile build.log
```

## Параметры сборки
| Параметр       | Значение      |
|----------------|---------------|
| Graphics API   | OpenGL ES 3.0 |
| Compression    | Disabled      |
| Template       | Default       |