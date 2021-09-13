dofile("./json.lua")

-- print(app.params["jsondata"])

data=decode(app.params["jsondata"])

app.open(app.params["file"])

frames = app.activeSprite.frames

for i, data_part in ipairs(data) do

    data_tag = data_part["tag"]
    data_times = data_part["times"]

    for i, tag in ipairs(app.activeSprite.tags) do
        if(tag.name == data_tag) then
            activeTag = tag
            break
        end
    end

    if(#data_times ~= activeTag.frames) then
        print("number of splits does not match number of frames")
        return
    end

    for i=activeTag.fromFrame.frameNumber,activeTag.toFrame.frameNumber do
        frames[i].duration = data_times[i-activeTag.fromFrame.frameNumber + 1]
    end
end


app.command.SaveFile()
app.command.CloseFile()
app.command.Exit()