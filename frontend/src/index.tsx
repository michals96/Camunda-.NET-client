import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import reportWebVitals from './reportWebVitals';
import RequestWindow from "./components/request-window/request-window";
import InstanceStatistics from "./components/instance-statistics/instance-statistics";

import styles from './index.module.scss';

const root = ReactDOM.createRoot(document.getElementById('root') as HTMLElement);
root.render(<React.StrictMode>
    <div className={styles.container}>
        <RequestWindow></RequestWindow>
        <InstanceStatistics></InstanceStatistics>
    </div>
</React.StrictMode>);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
