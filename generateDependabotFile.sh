# Find all subdirectories containing .csproj files
find . -type f -name "*.csproj" -exec dirname {} \; | sort | uniq > directories.txt

# Generate a list of Dependabot update entries
echo "version: 2" > dependabot.yml
echo "updates:" >> dependabot.yml

while read directory; do
    echo "  - package-ecosystem: \"nuget\"" >> dependabot.yml
    echo "    directory: \"$directory\"" >> dependabot.yml
    echo "    schedule:" >> dependabot.yml
    echo "      interval: \"weekly\"" >> dependabot.yml
done < directories.txt

# Commit and push the updated dependabot.yml
#git add dependabot.yml
#git commit -m "Update dependabot.yml with new directories"
#git push
