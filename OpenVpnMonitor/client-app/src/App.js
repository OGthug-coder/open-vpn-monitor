import React, {useEffect, useState} from 'react';
import {GetStatsByPeriod} from "./Api";
import Plotly from 'plotly.js-dist-min'

const getRequestModel = () => {
  const from = new Date("2022-09-19T17:30:06.566Z");
  const to = new Date("2022-09-19T17:50:06.566Z");
  return { from: from, to: to }
}

export function App() {
  const [data, setData] = useState(0);
  
  useEffect(() => {
    GetStatsByPeriod(getRequestModel())
        .then(x => setData(x));

    debugger
    Plotly.newPlot("myDiv", /* JSON object */ {
      "data": data.traces,
      "layout": { "width": 600, "height": 400}
    })
  })
  
  return <div id="myDiv"/>
}