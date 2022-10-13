export async function GetStatsByPeriod(model){
    const response = await fetch("api/stats", {
        method: "POST", 
        headers: {
            "content-type": "application/json"
        },
        body: JSON.stringify(model)})
    
    return await response.json();
}