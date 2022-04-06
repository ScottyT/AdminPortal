import React, { Component } from 'react';

export class ReportsData extends Component {
    static displayName = ReportsData.name;
    
    state = { reports: [], loading: true }

    componentDidMount() {
        this.populateReportsData()
    }

    async populateReportsData() {
        const response = await fetch('https://localhost:7032/reportslist');
        const data = await response.json();
        this.setState({ reports: data, loading: false})
    }

    static reportsListing(reports) {
        return (
            <div className='reports-list'>
                {reports.map(report => (
                    <div key={report.id} className='w-100'>{report.id}</div>
                ))}
            </div>
        )
    }

    render() {
        let contents = this.state.loading ? 
            <p><em>Loading...</em></p> : 
            ReportsData.reportsListing(this.state.reports);
        return(
           <div>
               {contents}
           </div>
        )
    }
}